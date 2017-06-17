# Time, memory, scalability and big O

Some of the main concerns when trying to analyze algorithms is to figure out how 'fast' they are and how much memory they will consume. These are important factors when it comes to writing complex software that has to do large calculations and handle big sets of data. In order to do these kinds of analysis we turn towards mathematical models to achieve a relatively precise estimations of an algorithm.

The approach is the same as used by scientist to analyze nature.

- Observe some feature of the natural world, generally with precise measurements.
- Hypothesize a model that is consistent with the observations.
- Predict events using the hypothesis.
- Verify the predictions by making further observations.
- Validate by repeating until the hypothesis and observations agree.

A hypothesis must be falsifiable, which means that even though our hypothesis seems accurate it can never be fact because with only one wrong prediction it should be able to tell that it is wrong and needs redoing. 

With complex mathematic equations for our hypothesis we usually cut of insignificant values to simplify the equation. To show this we use the ~(tilde) symbol. E.g. If we have N^3 + N 3 then N^3 it is substantially larger than N times 3. Which we would then rewrite to ~F(N) = N^3.

##### Time

In order to calculate time you can run your application with different sizes of data and then use the stopwatch library found in most common languages, plot the results in a diagram with x-axis being time and y-axis being amount of data. If you plot in your results in a log plot and get a straight line you can do the hypothesis that the time/amount is equivalent to the formula **T(N ) = a N^b**.

Knuth postulated that its possible to predict the running time of a program by determining two factors:

1. The cost of executing each statement
2. The frequency of execution of each statement

The cost of execution depends on the hardware and the language whereas the frequency is determined by the software itself. We usually look towards the instructions being run the most and refer to them as the inner loop. E.g.

``` java
for(int i = 0; i < 10: i++) {
  for(int j = 0; i < 20; i++) {
    if(i + j % 10 == 0) {
      System.out.printLn("We got a winner!");
    }
  }
}
```

In the above example the inner loop is the j for loop and the if statement checking for i + j modular 10 is 0.

##### Memory

As with the time of running an application or a specific algorithm, the amount of memory that needs to be used at a given point is also an important factor. The amount of memory used by an application is the same each time you run the application but can differ from machine to machine because of system differences in circuitry. Here is a list of typical memory requirements for primitive types:

| Type    | Bytes (8 bit) |
| ------- | ------------- |
| Boolean | 1             |
| byte    | 1             |
| char    | 2             |
| int     | 4             |
| float   | 4             |
| long    | 8             |
| double  | 8             |
To calculate the memory usage of an application we look at how many declarations are made. Complex data types are converted to primitive types so we are also able to easily include them in our calculation. So it is possible to count up the number of variables and thereby determining the memory needed to execute a specific task or application. But these calculations may vary from system to system. E.g. a 64-bit architecture uses 8 bytes for a machine address, hence the 64 bit.

To determine the memory usage of an object we take the amount used for each instance variable together with the overhead for the object which is usually 16 bytes which contains a reference to the object, garbage collection data and synchronization information. Usually we also have some padding e.g. an Integer object uses 24 bytes - 16 bytes for the overhead, 4 bytes for the int instance variable and then 4 bytes of padding. A linked list with integers uses 32 + 64N bytes - the usual 16 byte for overhead, 8 for instance reference  variable, 4 for int instance variable 4 for padding and 64 for each entry where 40 is for the Node and 24 is for the Integer object.

![Memory consumption](https://github.com//tjaydk/SoftDevDataAlgExam/blob/master/Img/primitiveMemory.JPG?raw=true)

##### Scalability

So the above information can be used to determine whether a piece of code is optimal for usage in a larger scale when handling large amounts of data or we have a demand for execution times to be very fast. So we strive after creating algorithms that don't consume to much memory or takes to long. This of course always depend on the demands for the application. As with some applications it is okay to use slower algorithms in order to save time when developing the software rather than having to do a lot of theoretical examination and experimentation in order to optimize algorithms.

##### Big-O

We use the Big O notation to indicate the time of running an application in regards to the growth of data. The common orders of growth are:

| Description  | Function |
| ------------ | -------- |
| Constant     | 1        |
| Logarithmic  | log N    |
| Linear       | N        |
| Linearithmic | N log N  |
| Quadratic    | N^2      |
| Cubic        | N^3      |
| Exponential  | 2^N      |
The Big O notation is used to indicate the upper boundary, or worse case scenario of an algorithm. It is still simplified, as explained in the introduction, so any insignificant values are removed. 

We always want to get the best algorithms possible as they can be the difference in being able to solve a problem or not.

##### Case 'Dynamic Connectivity'

The input is a sequence of pairs of integers, where each integer represents an object of some type and we are to interpret the pair p q as meaning “p is connected to q.” We assume that “is connected to” is an equivalence relation, which means that it is:

- Reflexive : p is connected to q.
- Symmetric : If p is connected to q, then q is connected to p.
- Transitive : If p is connected to q and q is connected to r, then p is connected to r.

If the program is evaluating a pair p q and the pairs seen to that point indicate that they are connected then we proceed, in the case that the pair is not connected we want to print that to the console. The design of said application is called the 'Dynamic Connectivity' and is used in a variety of applications such as networks, variable-name equivalence, mathematical sets etc. In the case we will use the network as base and call the objects sites and the bindings connections and the equivalence partitions as connected components.

We will have sites ranging from 0 to N-1 and we start of by determining our API:

```java
public class UF {
  public UF(int N) // initialize N sites with integer names (0 to N-1) 
  public void union(int p, int q) // add connection between p and q
  public int find(int p) // component identifier for p (0 to N-1)
  public boolean connected(int p, int q) // return true if p and q are in the same component
  public int count() // number of components
}
```

 We start of with creating the quick find algorithm which takes N^2 time because it has to go through each pair set every time union is called, and union is called for each node.

Afterwards we do a quick union algorithm which instead creates a tree structure and goes through each node like a link to link, setting a root node at the end. If the two nodes then have the same root node we know they are connected. This can in best case lower the cost to N but still a worst case of N^2

So finally we implement the Weighted quick-union where we change the the union to instead of connecting any of the trees to one another we ensure that it is always the smallest tree being attached to the larger tree. This means we can guarantee lg N performance instead.

> Proposition H. The depth of any node in a forest built by weighted quick-union for
> N sites is at most lg N.

> Proof: We prove a stronger fact by (strong) induction: The height of every tree of
> size k in the forest is at most lg k. The base case follows from the fact that the tree
> height is 0 when k is 1. By the inductive hypothesis, assume that the tree height of a
> tree of size i is at most lg i for all i < k. When we combine a tree of size i with a tree
> of size j with i <= j and i j = k, we increase the depth of each node in the smaller set
> by 1, but they are now in a tree of size i j = k, so the property is preserved because
> 1+ lg i = lg(i i )<= lg(i j ) = lg k.

| Algorithm                                | constructor | union       | finc        |
| ---------------------------------------- | ----------- | ----------- | ----------- |
| Quick find                               | N           | N           | 1           |
| Quick union                              | N           | tree height | tree height |
| Weighted Quick union                     | N           | lg N        | lg N        |
| weighted quick-union with path compresson | N           | amortized 1 | amortized 1 |

Amortized plots are when we plot our results into a diagram we then have some that are above expectation and some below, we then draw a line or curve so the pass in between the results which then gives us an amortized result or average.