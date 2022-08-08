namespace AbeliansDecomposition;

public static class Utils
{
    // Static constructors for creating at startup
    // all primes less than 10000 and the partition of integers less than 32
    static Utils()
    {
        Primes10000 = new(AllPrimes(10000));
        Partitions32 = IntPartitions(32);
    }

    // Primes Sequence
    static List<int> Primes10000;

    // Partitions of integers, 
    // for each key, the dictionary contains all partitions
    public static Dictionary<int, List<List<int>>> Partitions32;

    // Compute all primes less than n
    static IEnumerable<int> AllPrimes(int n)
    {
        var primes = new Queue<int>();
        for (int i = 2; i <= n; ++i)
        {
            var isprime = true;
            foreach (var p in primes)
            {
                if (p * p > i) break;
                if (i % p == 0)
                {
                    isprime = false;
                    break;
                }
            }

            if (isprime) primes.Enqueue(i);
        }
        return primes;
    }

    // Primes decompositions of an integer N
    // Return a sequence of tuple (p, pow)
    // N = (p0^pow0) x (p1^pow1) x (p2^pow3) x ... x (p_i^pow_i)
    // Example : The result for N=60 is {(2,2), (3,1), (5,1)}
    static List<(int p, int pow)> PrimesDecomposition(int n)
    {
        List<(int p, int pow)> decomp = new();
        var n0 = n;
        foreach (var p in Primes10000.Where(e => e <= n))
        {
            var pow = 0;
            while (n0 % p == 0)
            {
                ++pow;
                n0 /= p;
            }

            if (pow != 0)
                decomp.Add((p, pow));

            if (n0 == 1) break;
        }

        return decomp;
    }

    // Partitions of an integers until N
    // Return a dictionary where each key is mapped to a collection
    // of ordered sequence of integers
    // Example : 5 => {5}, {4,1}, {3,2}, {3,1,1}, {2,2,1}, {2,1,1,1}, {1,1,1,1,1}
    public static Dictionary<int, List<List<int>>> IntPartitions(int N)
    {
        List<List<int>> all = new();
        Queue<List<int>> q = new();
        q.Enqueue(new());

        while (q.Count != 0)
        {
            var l0 = q.Dequeue();
            var s = l0.Count == 0 ? 1 : l0.First();
            for (int k = s; k <= N; ++k)
            {
                var l1 = l0.ToList();
                l1.Insert(0, k);
                var sumL1 = l1.Sum();
                if (sumL1 <= N)
                {
                    q.Enqueue(l1);
                    all.Add(l1);
                }
                else
                    break;
            }
        }

        var sum = all.GroupBy(l0 => l0.Sum()).ToDictionary(a => a.Key, b => b.ToList());
        return sum;
    }

    // Compute Invariants Factors from 
    // the sequence of group type
    public static List<int> GroupType(params int[] it)
    {
        var primesDecomp = it.Select(PrimesDecomposition).ToList();
        if (primesDecomp.Any(i => i.Count > 1))
            throw new Exception("p or p^N only, where p is prime");

        var groupedPrimes = primesDecomp.Select(a => a.First()).GroupBy(a => a.p).ToDictionary(a => a.Key, b => b.Select(c => (int)Math.Pow(c.p, c.pow)).OrderByDescending(c => c).ToList());
        var primesChains = groupedPrimes.Select(a => a.Value).ToList();
        var mx = primesChains.Max(l0 => l0.Count);

        List<int> factors = new();
        for (int k = 0; k < mx; ++k)
        {
            int p = primesChains.Select(l1 => l1.Count > k ? l1[k] : 1).Prod();
            factors.Add(p);
        }

        return factors;
    }

    // Compute Canonical Equivalent of a product of Abelian Groups 
    public static List<int> CanonicEquivalent(params int[] it)
    {
        var it0 = it.SelectMany(PrimesDecomposition).Select(a => (int)Math.Pow(a.p, a.pow)).ToArray();
        return GroupType(it0);
    }

    // Compute for an integer N, all Invariants Factors
    // and all Elementaries Divisors
    public static List<(List<int> factors, List<int> elemDivs)> InvariantFactors(int N)
    {
        var primesDecomp = PrimesDecomposition(N);
        var maxPow = primesDecomp.Max(a => a.pow);
        Console.WriteLine($"Decomposition of Z{N}, max Factors : {maxPow}");
        var allChains = primesDecomp.Select(a => Partitions32[a.pow].Select(b => b.Select(pow => (int)Math.Pow(a.p, pow))));

        var all = new List<List<List<int>>>() { new() };
        foreach (var l0 in allChains)
        {
            var tmp = all.ToList();
            all.Clear();
            foreach (var l1 in l0)
                foreach (var l2 in tmp)
                    all.Add(l2.Append(l1).Select(l3 => l3.ToList()).ToList());
        }

        List<(List<int> factors, List<int> elemDivs)> result = new();
        foreach (var l0 in all)
        {
            var mx = l0.Max(l1 => l1.Count);
            List<int> factors = new();
            List<int> elemDivs = new();
            for (int k = 0; k < mx; ++k)
            {
                var l2 = l0.Where(l1 => l1.Count > k).Select(l1 => l1[k]).ToList();
                elemDivs.AddRange(l2);
                factors.Add(l2.Prod());
            }

            result.Add((factors, elemDivs));
        }

        result.Sort((a, b) => CompareSeq1(b.factors, a.factors));
        result.ForEach(a => a.elemDivs.Sort((a, b) => b.CompareTo(a)));

        return result;
    }

    // Compute then output in console all decompositions
    // of an integer N, Invariants Factors and Elementaries Divisors
    public static void AllDecompositions(int N)
    {
        var result = InvariantFactors(N);
        var resultStr = result.Select(a => (AbeliansToStr(a.factors), AbeliansToStr(a.elemDivs))).ToList();
        var digits = resultStr.Max(a => a.Item1.Length);
        digits = Math.Max(digits, "Invariants factors".Length);
        var fmt0 = $"{{0,-{digits}}}   {{1}}";
        var fmt1 = $"{{0,-{digits}}} = {{1}}";
        Console.WriteLine(fmt0, "Invariants factors", "Elementaries divisors");
        resultStr.ForEach(l => Console.WriteLine(fmt1, l.Item1, l.Item2));
        Console.WriteLine($"Total : {resultStr.Count}");
        Console.WriteLine();
    }

    // Format sequence int
    // Example : {8,15} => Z8  x Z15
    static string AbeliansToStr(List<int> factors)
    {
        var digits = factors.Max(a => $"{a}".Length);
        var fmt = $"Z{{0,-{digits}}}";
        return factors.Glue(" x ", fmt);
    }

    // Compute then output in console canonical
    // equivalent decomposition in invariants factors
    // from the sequence of group type
    public static void AbeliansFromGroupType(params int[] mods)
    {
        var it = mods.OrderBy(a => a).ToArray();
        var factors = GroupType(it);
        Console.WriteLine($"Group Type : ({it.Glue()})");
        Console.WriteLine("Equivalent  : {0}", factors.Glue(" x ", "Z{0}"));
        Console.WriteLine();
    }

    // Compute then output in console canonical
    // equivalent decomposition in invariants factors
    // from a product of Abelian Groups
    public static void CanonicDecomposition(params int[] it)
    {
        var factors = CanonicEquivalent(it);
        Console.WriteLine("{0} ~ {1}", it.Glue(" x ", "Z{0}"), factors.Glue(" x ", "Z{0}"));
    }

    // Product of a sequence of integers
    public static int Prod(this IEnumerable<int> it)
    {
        return it.Aggregate((a, b) => a * b);
    }

    // Formatting a sequence to a string 
    public static string Glue<U>(this IEnumerable<U> it, string sep = ",", string fmt = "{0}")
    {
        return string.Join(sep, it.Select(e => string.Format(fmt, e)));
    }

    // Sequence side by side contents Comparer 
    public static int CompareSeq1<U>(IEnumerable<U> it0, IEnumerable<U> it1) where U : IComparable<U>
    {
        var e0 = it0.GetEnumerator();
        var e1 = it1.GetEnumerator();
        while (e0.MoveNext() && e1.MoveNext())
        {
            var comp = e0.Current.CompareTo(e1.Current);
            if (comp != 0)
                return comp;
        }

        return 0;
    }
}
