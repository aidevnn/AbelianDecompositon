# Abelian Finite Groups decompositions

## Get Invariants Product Group from Group Type

```
Abelian.FromGroupType(2, 2, 3, 8, 9, 5);
Abelian.FromGroupType(4, 5, 3, 2, 5);
```
will output
```
Group Type : (2,2,3,5,8,9)
Equivalent  : Z2 x Z6 x Z360

Group Type : (2,3,4,5,5)
Equivalent  : Z10 x Z60
```

## Get canonical Decomposition 
```
Abelian.CanonicDecomposition(40, 48);
Abelian.CanonicDecomposition(40, 48, 64);
Abelian.CanonicDecomposition(45, 150, 75);
```
will output
```
Z40 x Z48 ~ Z8 x Z240
Z40 x Z48 x Z64 ~ Z8 x Z16 x Z960
Z45 x Z150 x Z75 ~ Z15 x Z75 x Z450
```

## Get all decompostions of $\mathbb{Z}_{360}$

```
Abelian.AllDecompositions(360);
```
will output
```
Decomposition of Z360, max Factors : 3
Invariants factors   Elementaries divisors
Z360               = Z5 x Z8 x Z9
Z2   x Z180        = Z2 x Z4 x Z5 x Z9
Z3   x Z120        = Z3 x Z3 x Z5 x Z8
Z2  x Z2  x Z90    = Z2 x Z2 x Z2 x Z5 x Z9
Z6  x Z60          = Z2 x Z3 x Z3 x Z4 x Z5
Z2  x Z6  x Z30    = Z2 x Z2 x Z2 x Z3 x Z3 x Z5
Total : 6
```

## Get all decompostions of $\mathbb{Z}_{4320}$

```
Abelian.AllDecompositions(4320);
```
will output
```
Decomposition of Z4320, max Factors : 5
Invariants factors                 Elementaries divisors
Z4320                            = Z5  x Z27 x Z32
Z2    x Z2160                    = Z2  x Z5  x Z16 x Z27
Z3    x Z1440                    = Z3  x Z5  x Z9  x Z32
Z4    x Z1080                    = Z4  x Z5  x Z8  x Z27
Z2    x Z2    x Z1080            = Z2  x Z2  x Z5  x Z8  x Z27
Z6   x Z720                      = Z2  x Z3  x Z5  x Z9  x Z16
Z2   x Z4   x Z540               = Z2  x Z4  x Z4  x Z5  x Z27
Z2   x Z2   x Z2   x Z540        = Z2  x Z2  x Z2  x Z4  x Z5  x Z27
Z3   x Z3   x Z480               = Z3  x Z3  x Z3  x Z5  x Z32
Z12  x Z360                      = Z3 x Z4 x Z5 x Z8 x Z9
Z2   x Z6   x Z360               = Z2 x Z2 x Z3 x Z5 x Z8 x Z9
Z2   x Z2   x Z2   x Z2   x Z270 = Z2  x Z2  x Z2  x Z2  x Z2  x Z5  x Z27
Z3   x Z6   x Z240               = Z2  x Z3  x Z3  x Z3  x Z5  x Z16
Z2   x Z12  x Z180               = Z2 x Z3 x Z4 x Z4 x Z5 x Z9
Z2   x Z2   x Z6   x Z180        = Z2 x Z2 x Z2 x Z3 x Z4 x Z5 x Z9
Z3   x Z12  x Z120               = Z3 x Z3 x Z3 x Z4 x Z5 x Z8
Z6   x Z6   x Z120               = Z2 x Z2 x Z3 x Z3 x Z3 x Z5 x Z8
Z2  x Z2  x Z2  x Z6  x Z90      = Z2 x Z2 x Z2 x Z2 x Z2 x Z3 x Z5 x Z9
Z6  x Z12 x Z60                  = Z2 x Z3 x Z3 x Z3 x Z4 x Z4 x Z5
Z2  x Z6  x Z6  x Z60            = Z2 x Z2 x Z2 x Z3 x Z3 x Z3 x Z4 x Z5
Z2  x Z2  x Z6  x Z6  x Z30      = Z2 x Z2 x Z2 x Z2 x Z2 x Z3 x Z3 x Z3 x Z5
Total : 21
```