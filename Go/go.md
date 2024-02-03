
# https://blog.learngoprogramming.com/about-go-language-an-overview-f0bee143597c
# https://github.com/dariubs/GoBooks
# https://go.dev/doc/effective_go
# https://en.wikipedia.org/wiki/Go_(programming_language)
# https://gobyexample.com/
# https://stackoverflow.blog/2020/11/02/go-golang-learn-fast-programming-languages/
# https://www.bairesdev.com/blog/what-is-golang-used-for/
# https://www.codecademy.com/learn/learn-go
# https://medium.com/geekculture/golang-the-good-the-bad-and-the-ugly-880270a85848
# https://www.bacancytechnology.com/blog/golang-web-frameworks
# https://medium.com/@livajorge7/exploring-the-best-golang-web-frameworks-a-comprehensive-guide-to-building-web-applications-with-daa3ae52b15c
# https://github.com/mingrammer/go-web-framework-stars
# https://github.com/avelino/awesome-go?tab=readme-ov-file#iterators
# https://reliasoftware.com/blog/top-10-best-golang-web-frameworks
# https://verpex.com/blog/website-tips/golang-frameworks
# https://www.calibraint.com/blog/top-golang-web-frameworks-for-development
# https://medium.com/@stellarani.seeli/golang-frameworks-you-must-know-4023c35afb80
# https://invedus.com/blog/best-golang-frameworks-for-the-programmers/

# Where is GO used:
# container services - Docker/Kubernetes
# network and cloud services - OpenShift, Terraform use Go to create APIs
# and high-performance web servers
# web services
# command-line utilities
# microservices
# data science

# go build hello_world.go
# go run hello_world.go

# var declares 1 or more variables
# you can declare multiple variables at once: var b, c int = 1, 2
# variables declared without a corresponding initialization are zero-valued: var e int
# the := syntax is shorthand for declaring and initializing a variable: f := "apple" / var f string = "apple"

# const declares constant values

# for j := 7; j <= 9; j++ { }

# if num := 9; num < 10 { }

# switch i {
# case 1:
#     fmt.Println("one")
# default:
#     fmt.Println("default")    
# }

# arrays: b := [5]int{1, 2, 3, 4, 5}

# slices: var s []string
# slices: s = make([]string, 3)
# s.append(s, "d")
# c := make([]string, len(s))
# copy(c, s)
# l := s[2:5]
# t := []string{"a", "b", "c"}

# maps: m := make(map[string]int)
# m["k1"] = 10
# v1 := m["k1"]
# delete(m, "k2")
# clear(m)
# _, prs := m["k2"]
# n := map[string]int{"foo": 1, "bar": 2}

# ranges: 
# nums := []int{2, 3, 4}
# for i, num := range nums { }
# kvs := map[string]string{"a": "apple", "b": "banana"}
# for k, v := range kvs { }

# functions:
# func plus(a int, b int) int { return a + b }

# multiple return values:
# func vals() (int, int) { return 3, 7 }

# variadic functions can be called with any number of trailing arguments
# func sum(nums ...int) { ... }
# nums := []int{1, 2, 3, 4}
# sums(nums...)

# closures and anonymous functions
# func intSeq() func() int {
#     i := 0
#     return func() int {
#         i++
#         return i
#     }
# }

# recursion:
# var fib func(n int) int
# fib = func(n int) int { }

# pointers: 
# func zeroptr(iptr *int) {
#     *iptr = 0    
# }

# Go string = read-only slice of bytes

# Go structs = typed collections of fields

# structs are mutable
# type person struct {
#    name string
#    age int    
# }
# s := person{name: "Sean", age: 50}

# methods can be defined for either pointer or value receiver types
# type rect struct {
#     width, height int    
# }

# func (r *rect) area() int {
#     return r.width * r.height       
# }

# func (r rect) perim() int {
#     return 2 * r.width + 2 * r.height    
# }

# r := rect{width: 10, height: 5}
# rp := &r

# interfaces are named collections of method signatures
# type geometry interface {
#    area() float64
#    perim() float64    
# }

# type rect struct {
#    width, height float64
# }

# func (r rect) area() float64 {
#    return r.width * r.height    
# }

# func (r rect) perim() float64 {
#    return 2 * r.width + 2 * r.height    
# }

# func measure(g geometry) {
#     fmt.Println(g)
#     fmt.Println(g.area())    
#     fmt.Println(g.perim())
# }

# struct embedding
# type base struct {
#     num int    
# }

# type container struct {
#     base    
#     str string
# }

# co := container {
#     base: base {
#         num: 1,      
#     },
#     str: "some name",
# }

# generics:
# type List[T any] struct {
#     head, tail *element[T]    
# }

# type element[T any] struct {
#     next *element[T]
#     val T   
# }

# func MapKeys[K comparable, V any](m map[K]V) []K {
#     r := make([]K, 0, len(m))
#     for k := range m {
#         r = append(r, k)      
#     }
#     return r    
# }

# errors: func f1(arg int) (int, error) {
#     if arg == 42 {
#         return -1, errors.New("can't work with 42")    
#     }
#     return arg + 3, nil    
# }

# it's also possible to use custom types as errors by implementing the Error()
# method on them

# goroutines are a lightweight thread of execution:
# run a function directly: f("directly")
# go f("goroutine")

# channels are the pipes that connect concurrent goroutines; you can send values
# into channels from one goroutine and receive those values into another goroutine

# messages := make(chan string)
# go func() { message <- "ping" }()
# msg := <- message

# channel buffering: by default channels are unbuffered, meaning that they will
# only accept sends (chan <-) if there is a corresponding receive (<- chan)
# buffered channels accept a limited number of values without a corresponding 
# receiver for those values

# messages := make(chan string, 2)
# messages <- "buffered"
# messages <- "channel"
# fmt.Println(<-messages)
# fmt.Println(<-messages)

# channel sync:
# func worker(done chan bool) {
#     done <- true    
# }
# func main() {
#     done := make(chan bool, 1)
#     go worker(done)    
#     <-done
# }

# channel directions: when using channels as function parameters, you can 
# specify if a channel is meant to only send or receive values (for increased
# type safety)

# func ping(pings chan<- string, msg string) {
#     pings <- msg    
# }

# func ping(pings <-chan string, pongs chan<- string) {
#     msg := <-pings    
#     pongs <- msg
# }

# select lets you wait on multiple channel operations
# c1 := make(chan string)
# c2 := make(chan string)
# select {
# case msg1 := <-c1:
#    fmt.Println("received", msg1)
# case msg2 := <-c2:
#    fmt.Println("received", msg2)    
# }

# timeouts are important for programs that connect to external resources
# or that otherwise need to bound execution time

# c1 := make(chan string, 1)
# select {
# case res := <-c1:    
#    fmt.Println(res)
# case <-time.After(1 * time.Second):
#    fmt.Println("timeout 1)
# }

# basic sends and received on channels are blocking, but you can use select
# with a default clause to implement non-blocking sends, receives, and even
# non-blocking multi-way selects

# closing a channel indicates that no more values will be sent to it
# jobs := make(chan int, 5)
# done := make(chan bool)
# j, more := <-jobs
# done <-true
# close(jobs)
# <-done

# you can also range over channels
# queue := make(chan string, 2)
# for elem := range queue {
#     fmt.Println(elem)    
# }

# one advantage of a timer over a sleep is that you can cancel the timer
# before it fires
# timer := time.NewTimer(time.Second)
# go func() {
#     <-timer2.C
#     fmt.Println("Timer 2 fired")   
# }()
# stop := timer.Stop()

# timers are for when you want to do something once in the future, tickers are 
# for when you want to do something repeatedly at regular intervals

# ticker := time.NewTicker(500 * time.Millisecond)
# case t := <-ticker.C
# time.Sleep(1600 * time.Millisecond)
# ticker.Stop()

# worker pools
# func worker(id int, <-chan int, results chan<- int) {
#    for j := range jobs {
#        results <- j * 2
#    }    
# }
# 
# const numJobs = 5
# jobs := make(chan int, numJobs)
# results := make(chan int, numJobs)
# 
# for w := 1; w <= 3; w++ {
#     go worker(w, jobs, results)    
# }
# for j := 1; j <= numJobs; j++ {
#    jobs <- j   
# }
# close(jobs)
# for a := 1; a <= numJobs; a++ {
#     <-results    
# }

# to wait for multiple goroutines to finish, we can use a wait group
# func worker(id int) {}
# func main() {
#     var wg sync.WaitGroup
#     for i := 1; i <= 5; i++ {
#         wg.Add(1)    
#         i := i
#     }
#     wg.Wait()    
# }

# rate limiting
# requests := make(chan int, 5)
# for i := 1; i <= 5; i++ {
#     requests <- i    
# }
# close(requests)
# limiter := time.Tick(200 * time.Millisecond)
# for req := range requests {
#     <-limiter    
#     fmt.Println("request", req, time.Now())
# }

# atomic counters
# var ops atomic.Uint64
# var wg sync.WaitGroup
# for i := 0; i < 50; i++ {
#     wg.Add(1)
#     go func() {
#         for c := 0; c < 1000; c++ {
#             ops.Add(1)    
#         }
#         wg.Done()        
#     }()
# }
# wg.Wait()
# fmt.Println("ops:", ops.Load())

# for more complex state we can use a mutex to safely access data across
# multiple goroutines

# type Container struct {
#     mu sync.Mutex
#     counters map[string]int    
# }
# func (c *Container) inc(name string) {
#     c.mu.Lock()    
#     defer c.mu.Unlock()
#     c.counters[name]++
# }

# stateful goroutines
# var readOps uint64
# atomic.AddUint64(&readOps, 1)
# readOpsFinal := atomic.LoadUint64(&readOps)
# fmt.Println("readOps:", readOpsFinal)

# sorting: "slices" package
# ints := []int{7, 2, 4}
# slices.Sort(ints)
# s := slices.IsSorted(ints)

# sorting by functions:
# fruits := []string{"peach", "banana", "kiwi"}
# lenCmp := func(a, b string) int {
#     return cmp.Compare(len(a), len(b))    
# }
# slices.SortFunc(fruits, lenCmp)

# type Person struct {
#     name string    
#     age int
# }
# slices.SortFunc(people,
#     func(a, b Person) int {
#         return cmp.Compare(a.age, b.age)    
#     })

# a panic typically means something went unexpectedly wrong
# panic("a problem")

# defer is used to ensure that a function call is performed later in a program's
# execution, usually for the purposes of cleanup
# func main() {
#     f := createFile("/tmp/defer.txt")    
#     defer closeFile(f)
#     writeFile(f)
# }

# a recover can stop a panic from aborting the program and let it continue
# with execution instead
# if r := recover(); r != nil {}

# string functions:
# import s "strings"
# s.Contains, s.Count, s.HasPrefix, s.HasSuffix, s.Index, s.Join, s.Repeat
# s.Replace, s.Split, s.ToLower, s.ToUpper

# there is an entire list of string formatting
# text templates are used for creating dynamic content or showing customized
# output to the user with the text/template package













### Go books
#### 1. Learning Go - Jon Bodner (2024) - good
#### 2. 100 Go Mistakes and How to Avoid Them - Teiva Harsanyi (2022) - good
#### 3. Practical Go - Amit Saha (2021) - good
#### 4. Cloud Native Go - Matthew Timus (2021) - good
#### 5. Hands-On Software Engineering with Golang - Achilleas (2020) - good
#### 6. Head First Go - Jay McGavren (2019) - good
#### 7. Security with Go - John Daniel Leon (2018) - good
#### 8. Concurrency in Go - Katherine Cox-Buday (2017) - good
#### 9. The Go Programming Language - Alan Donovan (2015) - good
#### 10. Go in Action - William Kennedy (2015) - good

### Maybe:
#### 1. The Go Workshop - Dello D'Anna (2019) - just skim it
#### 2. Go Programming Blueprints - Seocnd Edition (2016) - Mat Ryer - good project ideas
#### 3. Hands-On Dependency Injection In Go - Carey Scott (2018) - Dependency Injection With Monkey Patching/Constructor Injection/Method Injection/By Config/Just-In-Time/Off-The-Shelf
#### 4. Go Cookbook - Sau Sheong Chang (2023) - just skim it
#### 5. Mastering Go - Third Edition - Mihalis Tsoukalos (2021) - just skim it
#### 6. Network Programming with Go - Adam Woodbeck (2021) - just skim it
#### 7. Distributed Services With Go - Travis Jeffery (2021) - just skim it
#### 8. Black Hat Go - Tom Steele (2020) - just skim it
#### 9. Go Programming Cookbook - Aaron Torres (2019) - just skim it
#### 10. Hands-On Programming with Go - Alex Guerrieri (2019) - just skim it
#### 11. Get Programming with Go - Nathan Youngman (2018) - just skim it



##############################################################################
##############################################################################
##############################################################################
##############################################################################
# https://learning.oreilly.com/library/view/100-go-mistakes/9781617299599/

##############################################################################
### 2 Code And Project Organization
##############################################################################

##############################################################################
### 3 Data Types
##############################################################################

# 3.1 #17: Creating confusion with octal literals
# sum := 100 + 010 
# result is 108, because 010 is actually 8
# to avoid confusion, use: file, err := os.OpenFile("foo", os.O_RDONLY, 0o664)

# 3.2 #18: Neglecting integer overflows
# var counter int32 = math.MaxInt32
# counter++
# counter is -2147483648
# to detect the overflow:
# if counter == math.MaxInt32 {
#     panic("int32 overflow")    
# }
# for detecting integer overflow during addition or multiplication, things are
# a little bit more complicated

# 3.3 #19: Not understanding floating points
# float32 and float64 are approximations and because of that, we have the rules:
# 1. when comparing two floating-point numbers, check that their difference is
# within an acceptable range
# 2. when performing additions and substractions, group operations with a 
# similar order of magnitude for better accuracy
# 3. to favor accuracy, if a sequence of operations requires addition, substraction,
# multiplication, or division, perform the multiplication and division first

# 3.4 #20: Not understanding slice length and capacity
# in Go, a slice is backed by an array
# s := make([]int, 3, 6)
# s = append(s, 2)
# slice length is the number of available elements in the slice
# slice capacity is the number of elements in the backing array
# adding an element to a full slice (length == capacity) leads to creating
# a new backing array with a new capacity, copying all the elements from the
# previous array, and updating the slice pointer to the new array

# 3.5 #21: Inefficient slice initialization
# func convert(foos []Foo) []Bar {
#     n := len(foos)
#     bars := make([]Bar, 0, n)
#     for _, foo := range foos {
#         bars.append(bars, fooTobar(foo))
#     }
#     return bars    
# }   

# 3.6 #22: Being confused about nil vs empty slices
# a nil slice equals nil, whereas an empty slice has a length of zero
# a nil slice is empty, but an empty slice isn't necessarily nil
# a nil slice doesn't require any allocation
# var s [string]    // empty and nil
# s = []string(nil) // empty and nil
# s = []string{}    // empty and not nil
# s = make([]string, 0) // empty and not nill

# 3.7 #23: Not properly checking if a slice is empty
# checking the length of the slice is the best way
# erroneous:
# if operations != nil {
#     handle(operations)    
# }

# 3.8 #24: Not making slice copies correctly
# src := []int{0, 1, 2}
# dst := make([]int, len(src)) // var dst []int will not work due to zero size
# copy(dst, src)
# fmt.Println(dst)

# 3.9 #25: Unexpected side effects using slice append
# if the resulting slice has a length smaller than its capacity, append can
# mutate the original slice
# if you want to restrict the range of possible side effects, we can use either
# a slice copy or the full slice expression, which prevents us from doing a copy
# s := []int{1, 2, 3}
# sCopy := make([]int, 2)
# copy(sCopy, s)
# f(sCopy)
# result := append(sCopy, s[2])

# 3.10 #26: Slices and memory leaks
# func getMessageType(msg []byte) []byte {
#     msgType := make([]byte, 5)
#     copy(msgType, msg)
#     return msgType
# }
# remember that slicing a large slice or array can lead to potential high
# memory consumption because the remaining space won't be reclaimed by the GC

# 3.11 #27: Inefficient map initialization
# a map is based on the hash table data structure (array of buckets, where
# each bucket is a pointer to an array of key-value pairs)
# if you know the number of elements from the start, initialize the map as follows:
# m := make(map[string]int, 1_000_000)

# 3.12 #28: Maps and memory leaks
# a Go map can only grow in size, so does its memory consumption
# solutions are to force Go to re-create the map or using pointers to check
# if it can be optimized

# 3.13 #29: Comparing values incorrectly
# how do == and != make comparisons
# 1. booleans - compare whether the two Booleans are equal
# 2. numeric (int, float, complex types) - compare whether two numerics are equal
# 3. strings - compare whether two strings are equal
# 4. channels - compare whether two channels were created by the same call to make
# or if both are nil
# 5. interfaces - compare whether two interfaces have identical dynamic types
# and equal dynamic values or if both are nil
# 6. pointers - compare whether two pointers point to the same value in memory
# or if both are nil
# 7. structs and arrays - compare whether they are composed of similar types
# otherwise, you can either use reflect.DeepEqual and pay the price of reflection
# or use custom implementations and libraries

##############################################################################
# 4 Control Structures
##############################################################################
# 4.1 #30: Ignoring the fact that elements are copied in range loops
# s := []string{"a", "b", "c"}
# for i, v in range s { }
# in Go, everything we assign is a copy:
# - if we assign the result of a function returning a struct, it performs a copy of that struct
# - if we assign the result of a function returning a pointer, it performs a
# copy of the memory address
# to update slice elements, use the index

# 4.2 #31: Ignoring how arguments are evaluated in range loops
# when using a range loop, the provided expression is evaluated only once
# when using a for loop, the expression is evaluated at each step

# 4.3 #32: Ignoring the impact of using pointer elements in range loops
# if we store large structs, and these structs are frequently mutated, we can use pointers
# instead to avoid a copy and an insertion for each mutation
# func updateMapPointer(mapPointer map[string]*LargeStruct, id string) {
#     mapPointer[id].foo = "bar"    
# }
# interesting mistake, to revisit

# 4.4 #33: Making wrong assumptions during map iterations
# the map data structure does not keep the data ordered by key
# the map does not preserv the order in which the data was added
# the map is not iterated in a deterministic order
# you can't rely that an element will be produced in the same iteration in
# which it's added

# 4.5 #34: Ignoring how the break statement works
# the break will exit the inner-most for, switch or select statement
# for a more complicated scenario, use labels

# 4.6 #35: Using defer inside a loop
# defer schedules a function call when the surrounding function returns
# calling defer within a loop will stack all the calls, they won't be executed
# during each iteration, which may cause memory leaks if the loop doesn't terminate

##############################################################################
# 5 Strings
##############################################################################
# 5.1 #36: Not understanding the concept of a rune
# 5.2 #37: Inaccurate string iteration
# 5.3 #38: Misusing trim functions
# 5.4 #39: Under-optimized string concatenation
# 5.5 #40: Useless string conversions
# 5.6 #41: Substrings and memory leaks 

##############################################################################
### 6 Functions and methods
##############################################################################
#### 6.1 #42: Not knowing which type of receiver to use
- with a value receiver, Go makes a copy of the value and passes it to the method
- with a pointer receiver, Go passes the address of an object to the method
- the correct way to modify the balance:
```
type customer struct {
    balance float64    
}
func (c *customer) add(operation float64) {
    c.balance += operation    
}
```
- a receiver must be a pointer:
    - if the method needs to mutate the receiver
    - if the method receiver contains a field that cannot be copied
- a receiver should be a pointer:
    - if the receiver is a large object
- a receiver must be a value:
    - if we have to enforce a receiver's immutability
    - if the receiver is a map, function, or channel
- a receiver should be a value:
    - if the receiver is a slice that doesn't have to be mutated
    - if the receiver is a small array or struct that is naturally a value type
    - without mutable fields, such as time.Time
    - if the receiver is a basic type such as int, float64, string

#### 6.2 #43: Never using named result parameters
- b is also initialized to their zero value
```
func f(a int) (b int) {
    b = a    
    return
}
```

#### 6.3 #44: Unintended side effects with named result parameters
- because each name result parameter is initialized to their zero value
this can lead to subtle bugs

#### 6.4 #45: Returning a nil receiver
- having a nil receiver is allowed, and an interface converted from a nil
- pointer isn't a nil interface
- when we have to return an interface, we should return not a nil pointer, but
- a nil value directly

#### 6.5 #46: Using a filename as a function input
- instead of using:
```func countEmptyLinesInFile(filename string) (int, error) {}```
- use:
```func countEmptyLines(reader io.Reader) (int, error) {}```
- accepting a filename as a function input to read from a file should, in most
cases, be considered a code smell; using the io.Reader interface abstracts the
data source (regardless whether the input is a file, a string, an HTTP request, 
or a gRPC request)

#### 6.6 #47: Ignoring how defer arguments and receivers are evaluated
- using defer evaluates the arguments right away (use address of variable)  
```
const (
    StatusSuccess = "success"
    StatusErrorFoo = "error_foo"
    StatusErrorBar = "error_bar
)

func f() error {  
    var status string  
    defer notify(&status)  
    defer incrementCounter(&status)


    if err := foo(); err != nil {  
        status = StatusErrorFoo
        return err
    }

    if err := bar(); err != nil {
        status = StatusErrorBar
        return err
    }

    status = StatusSuccess
    return nil
}
```
or we could have used closures:
```
func f() error {
    var status string
    defer func() {
        notify(status)
        incrementCounter(status)
    }()
}
```
- for a method, the receiver is also evaluated immediately
```
func main() {
    s := &Struct{id: "foo"}
    defer s.print()
    s.id = "bar"
}
```

##############################################################################
### 7 Error management
##############################################################################
#### 7.1 #48: Panicking
- error management should be done with a function that returns a proper error type
as the last parameter
- the proper way to use defer + panic + recover

```
func main() {
    defer func () {
        if r := recover(); r != nil {
            fmt.Println("recover", r)
        }
    }()

    f()
}

func f() {
    fmt.Println("a")
    panic("foo")
    fmt.Println("b")
}

```

#### 7.2 #49: Ignoring when to wrap an error  
- reasons to do it:
    - adding additional context to an error
    - marking an error as a specific error
- to wrap an error:
```
if err != nil {
    return fmt.Errorf("bar failed: %w", err)
}
```
- to transform an error:
```
if err != nil {
    return fmt.Errorf("bar failed: %v", err)
}
```

#### 7.3 #50: Checking an error type inaccurately
- use errors.As to check an error is a specific type
```
type transientError struct {
    err error
}

func (t transientError) Error() string {
    return fmt.Sprintf("transient error: %v", t.err)
}

func getTransactionAmountFromDB(transactionID string) (float32, error) {
    // ...
    if err != nil {
        return 0, transientError(err: err)
    }
    // ...
}

func getTransactionAmount(transactionID string) (float32, error) {
    if len(transactionID) != 5 {
        return 0, fmt.Errorf("id is invalid: %s", transactionID)
    }

    // assume this returns a transientError
    amount, err := getTransactionAmountFromDB(transactionID)
    if err != nil {
        // replaced this line
        // return 0, transientError(err: err)
        return 0, fmt.Errorf("failed to get transaction %s: %w", transactionID, err)
    }
    return amount, nil
}

func handler(w http.ResponseWriter, r *http.Request) {
    // get transaction ID

    amount, err := getTransactionAmount(transactionID)
    if err != nil {
        if errors.As(err, &transientError{}) {
            http.Error(w, err.Error(), http.StatusServiceUnavailable)
        } else {
            http.Error(w, err.Error(), http.StatusBadRequest)
        }
        return
    }
}
```

#### 7.4 #51: Checking an error value inaccurately
- sentinel errors convey an expected error that clients will expect to check
```
var ErrFoo = errors.New("foo")
```
- unexpected errors should be designed as error types
```
type BarError struct { ... }
```
- errors.Is can recursively unwrap an error and compare each error in the chain
against the provided value
```
err := query()
if err != nil {
    if errors.Is(err, sql.ErrNoRows) {
        // ...
    } else {
        // ...
    }
}

```

#### 7.5 #52: Handling an error twice
#### 7.6 #53: Not handling an error
#### 7.7 #54: Not handling defer errors

##############################################################################
### 8 Concurrency: Foundations
##############################################################################
#### 8.1 #55: Mixing up concurrency and parallelism
#### 8.2 #56: Thinking concurrency is always faster
#### 8.3 #57: Being puzzled about when to use channels or mutexes
#### 8.4 #58: Not understanding race problems
#### 8.5 #59: Not understanding the concurrency impact of a workload type
#### 8.6 #60: Misunderstanding Go contexts

##############################################################################
### 9 Concurrency: Practice
##############################################################################

##############################################################################
### 10 The Standard Library
##############################################################################

##############################################################################
### 11 Testing
##############################################################################

##############################################################################
### 12 Optimizations
##############################################################################




##############################################################################
##############################################################################
##############################################################################
##############################################################################
# Learning Go, Second Edition

##############################################################################
# C1. Setting Up Your Go Environment
##############################################################################
# go mod init (to mark this directory as a Go module)
# a module is also an exact specification of the dependencies of the code
# within the module
# go fmt file.go (automatically fixes the whitespace in your code to match
# the standard format)
# go vet file.go (to catch common programming errors)
# example of a makefile:
# .DEFAULT_GOAL := build
# 
# .PHONY:fmt vet build
# fmt:
#        go fmt ./...
#
# vet: fmt
#        go vet ./...
#
# build: vet
#        go build
# to run the Makefile, call "make"

##############################################################################
# C2. Predeclared Types and Declarations
##############################################################################
# you must always use explicit conversion
# var x int = 10
# var b byte = 100
# var sum3 int = x + int(b)
# var sum4 byte = byte(x) + b

# untyped constant: const x = 10
# typed constant: const typedX int = 10

##############################################################################
# C3. Composite Types
##############################################################################
# var x [3]int (array)
# var x = []int{10, 20, 30} (slice)
# len(x), x = append(x, 40), x := make([]int, 5), clear(x)
# to avoid complicated slice situations, you should either never use append
# with a subslice or make sure that append doesn't cause an overwrite by using
# a full slice expression
# to convert an array to a slice:
# xArray := [4]int{5, 6, 7, 8}
# xSlice := xArray[:]

# to convert a slice to an array:
# xSlice := []int{1, 2, 3, 4}
# xArray := [4]int(xSlice)
# maps: map[keyType]valueType
# totalWins := map[string]int{}
# ages := make(map[int]string, 10)
# the comma ok idiom: v, ok := m["world"]
# m := map[string]int {
#     "hello": 5,
#     "world": 10,    
# }
# delete(m, "hello")
# clear(m)
# to compare maps: maps.Equal, maps.EqualFunc
# to compare slices: slices.Equal, slices.EqualFunc
# you can use a map to emulate a set
# you can also initialize anonymous structs

##############################################################################
# C4. Blocks, Shadows, And Control Structures
##############################################################################
# 

# C5. Functions
# C6. Pointers
# C7. Types, Methods, And Interfaces 




##############################################################################
# 31st Jan 2024 - 15 mins of 100 Mistakes & 15 mins of searching the Internet
# 1st Feb 2024 - TODO
# 2nd Feb 2024 - TODO


