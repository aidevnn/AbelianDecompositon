# Abelian Finite Groups decompositions

## Get Invariants Product Group from Group Type

```
Utils.AbeliansFromGroupType(2, 2, 3, 8, 9, 5);
Utils.AbeliansFromGroupType(4, 5, 3, 2, 5);
```
will output
```
Group Type : (2,2,3,5,8,9)
Equivalent  : Z360 x Z6 x Z2

Group Type : (2,3,4,5,5)
Equivalent  : Z60 x Z10
```

## Get canonical Decomposition 
```
Utils.CanonicDecomposition(40, 48);
Utils.CanonicDecomposition(40, 48, 64);
Utils.CanonicDecomposition(45, 150, 75);
```
will output
```
Z40 x Z48 ~ Z240 x Z8
Z40 x Z48 x Z64 ~ Z960 x Z16 x Z8
Z45 x Z150 x Z75 ~ Z450 x Z75 x Z15
```

## Get all decompostions of Z360

```
Utils.AllDecompositions(360);
```
will output
```
Decomposition of Z360, max Factors : 3
Invariants factors   Elementaries divisors
Z360               = Z9 x Z8 x Z5
Z180 x Z2          = Z9 x Z5 x Z4 x Z2
Z120 x Z3          = Z8 x Z5 x Z3 x Z3
Z90 x Z2  x Z2     = Z9 x Z5 x Z2 x Z2 x Z2
Z60 x Z6           = Z5 x Z4 x Z3 x Z3 x Z2
Z30 x Z6  x Z2     = Z5 x Z3 x Z3 x Z2 x Z2 x Z2
Total : 6
```

## Get all decompostions of Z4320

```
Utils.AllDecompositions(4320);
```
will output
```
Decomposition of Z4320, max Factors : 5
Invariants factors                 Elementaries divisors
Z4320                            = Z32 x Z27 x Z5 
Z2160 x Z2                       = Z27 x Z16 x Z5  x Z2 
Z1440 x Z3                       = Z32 x Z9  x Z5  x Z3 
Z1080 x Z4                       = Z27 x Z8  x Z5  x Z4 
Z1080 x Z2    x Z2               = Z27 x Z8  x Z5  x Z2  x Z2 
Z720 x Z6                        = Z16 x Z9  x Z5  x Z3  x Z2 
Z540 x Z4   x Z2                 = Z27 x Z5  x Z4  x Z4  x Z2 
Z540 x Z2   x Z2   x Z2          = Z27 x Z5  x Z4  x Z2  x Z2  x Z2 
Z480 x Z3   x Z3                 = Z32 x Z5  x Z3  x Z3  x Z3 
Z360 x Z12                       = Z9 x Z8 x Z5 x Z4 x Z3
Z360 x Z6   x Z2                 = Z9 x Z8 x Z5 x Z3 x Z2 x Z2
Z270 x Z2   x Z2   x Z2   x Z2   = Z27 x Z5  x Z2  x Z2  x Z2  x Z2  x Z2 
Z240 x Z6   x Z3                 = Z16 x Z5  x Z3  x Z3  x Z3  x Z2 
Z180 x Z12  x Z2                 = Z9 x Z5 x Z4 x Z4 x Z3 x Z2
Z180 x Z6   x Z2   x Z2          = Z9 x Z5 x Z4 x Z3 x Z2 x Z2 x Z2
Z120 x Z12  x Z3                 = Z8 x Z5 x Z4 x Z3 x Z3 x Z3
Z120 x Z6   x Z6                 = Z8 x Z5 x Z3 x Z3 x Z3 x Z2 x Z2
Z90 x Z6  x Z2  x Z2  x Z2       = Z9 x Z5 x Z3 x Z2 x Z2 x Z2 x Z2 x Z2
Z60 x Z12 x Z6                   = Z5 x Z4 x Z4 x Z3 x Z3 x Z3 x Z2
Z60 x Z6  x Z6  x Z2             = Z5 x Z4 x Z3 x Z3 x Z3 x Z2 x Z2 x Z2
Z30 x Z6  x Z6  x Z2  x Z2       = Z5 x Z3 x Z3 x Z3 x Z2 x Z2 x Z2 x Z2 x Z2
Total : 21
```