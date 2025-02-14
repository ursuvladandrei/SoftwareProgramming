import sun.invoke.empty.Empty
import java.util.concurrent.BlockingQueue
import java.util.concurrent.LinkedBlockingQueue
import java.util.concurrent.Semaphore
import kotlin.properties.Delegates
import kotlin.collections.listOf
import kotlin.concurrent.thread

fun main() {
    println("Hello World!")
    fizzbuzz(1, 20)
    val sub = Submarine()
    sub.fire()
    sub.submerge()

    // testing overriding member extension function
    val selenium = Element("Selenium")
    selenium.react(Particle())
    selenium.react(Electron())

    val neon = NobleGas("Neon")
    neon.react(Particle())
    neon.react(Electron())

    var arrayList: kotlin.collections.List<Int> = listOf(1, 2, 3, 4)

    maps()
    sets()
    testProducerConsumer()
}

fun arrays() {

}

fun lists() {

}

fun maps() {
    data class Customer(val firstName: String, val id: Int)

    val carsMap: Map<String, String> = mapOf("a" to "aston martin", "b" to "bmw")
    println("car[${carsMap.javaClass.canonicalName}:$carsMap]")
    println("car maker starting with b: ${carsMap.get("b")}")

    var states: MutableMap<String, String> = mutableMapOf("AL" to "Alabama", "AK" to "Alaska")
    states += ("CA" to "California")
    println("states keys: ${states.keys}")
    println("states values: ${states.values}")

    val customers: java.util.HashMap<Int, Customer> = hashMapOf(1 to Customer("Dina", 1), 2 to Customer("Mike", 2))
    val linkedHashMap: java.util.LinkedHashMap<String, String> = linkedMapOf("red" to "#FF0000")
    val sortedMap: java.util.SortedMap<Int, String> = sortedMapOf(4 to "d", 1 to "3")
}

fun sets() {
    data class Book(val author: String)

    val intSet: Set<Int> = setOf(1, 21, 2, 1)
    val hashSet: java.util.HashSet<Book> = hashSetOf(
        Book("Jules Verne"),
        Book("George R.R. Martin")
    )
    println("set of books: ${hashSet}")

    val sortedIntegers: java.util.TreeSet<Int> = sortedSetOf(11, 0, 9, 9)
    val charSet: java.util.LinkedHashSet<Char> = linkedSetOf('a', 'x', 'a')
    val longSet: MutableSet<Long> = mutableSetOf(1000, 2000, 3000)
}

class ProducerTask(val queue: BlockingQueue<Int>) {

    @Volatile var running = true

    fun run() {
        while (running) {
            Thread.sleep(1000)
            queue.put(kotlin.random.Random.nextInt())
        }
    }
}

class ConsumerTask(val queue: BlockingQueue<Int>) {

    @Volatile var running = true

    fun run() {
        while (running) {
            val element = queue.take()
            println("I am processing element $element")
        }
    }
}

fun testProducerConsumer()
{
    var queue = LinkedBlockingQueue<Int>()

    val consumerTasks = (1..6).map { ConsumerTask(queue) }
    val producerTask = ProducerTask(queue)

    val consumerThreads = consumerTasks.map { thread {it.run() } }
    val producerThread = thread { producerTask.run() }

    Thread.sleep(5000)

    consumerTasks.forEach { it.running = false }
    producerTask.running = false
}

fun semaphores() {
    val emptyCount = Semaphore(8)
    val fillCount = Semaphore(0)
    val mutex = Semaphore(1)
    val buffer = mutableSetOf<Int>()

    thread {
        while (true) {
            emptyCount.acquire()
            mutex.acquire()
            buffer.plus(kotlin.random.Random.nextInt())
            mutex.release()
            fillCount.release()
        }
    }

    thread {
        while (true) {
            fillCount.acquire()
            mutex.acquire()
            val item = buffer.remove(0)
            mutex.release()
            println("Consumed item $item")
            emptyCount.release()
        }
    }

}



fun fizzbuzz(start: Int, end: Int): Unit {
    fun isFizz(k: Int): Boolean = (k % 3 == 0)
    fun isBuzz(k: Int): Boolean = (k % 5 == 0)

    for (k in start..end) {
        if (isFizz(k) && isFizz(k))
            println("$k Fizz Buzz")
        else if (isFizz(k))
            println("$k Fizz")
        else if (isBuzz(k))
            println("$k Buzz")
        else
            println("$k")
    }
}

class Submarine {
    fun fire(): Unit {
        println("Firing torpedoes")
    }
    fun submerge(): Unit {
        println("Submerging")
    }
}

fun fire(): Unit {
    println("Fire on board")
}

fun Submarine.submerge(): Unit {
    println("Submerging to a depth")
}

open class Particle {}

class Electron : Particle() {}

open class Element(val name: String) {
    open fun Particle.react(name: String): Unit {
        println("$name is reacting with a particle")
    }

    open fun Electron.react(name: String): Unit {
        println("$name is reacting with an electron to make an isotope")
    }

    fun react(particle: Particle): Unit {
        particle.react(name)
    }
}

class NobleGas(name: String): Element(name) {
    override fun Particle.react(name: String): Unit {
        println("$name is noble, it doesn't react with particles")
    }
    override fun Electron.react(name: String): Unit {
        println("$name is noble, it doesn't react with electrons")
    }
    fun react(particle: Electron) : Unit {
        particle.react(name)
    }
}

class Matrix(val a: Int, val b: Int, val c: Int, val d: Int) {
    operator fun plus(matrix: Matrix): Matrix {
        return Matrix(a + matrix.a, b + matrix.b, c + matrix.c, d + matrix.d)
    }
}

enum class Piece {
    Emply, Pawn, Bishop, Knight, Rook, Queen, Kin
}

class ChessBoard() {
    private val board = Array<Piece>(64, {Piece.Emply })
    operator fun get(i: Int, j: Int): Piece = board[i * 8 + j]

    operator fun set(rank: Int, value: Piece): Unit {
        board[rank * 8 + rank] = value
    }
}

fun <T> printRepeat(t: T, k: Int): Unit {
    for (x in 0..k) {
        println(t)
    }
}

// Higher-order functions
fun foo(str: String, fn: (String) -> String): Unit {
    val applied = fn(str)
    println(applied)
}

fun <A, B, C> compose(fn1: (A) -> B, fn2: (B) -> C): (A) -> C = { a ->
    val b = fn1(a)
    val c = fn2(b)
    c
}

class Student(name: String, age: Int) {
    public var Name = ""
        set(value) {
            field = value
        }

    public var Age = 20
        set(value) {
            field = value
        }

    init {
        Name = name
        Age = age
    }
}

class WithObservableProp {
    var value: Int by Delegates.observable(0) {p, oldNew, newVal -> onValueChanged()}

    private fun onValueChanged() {
        println("value has changed: $value")
    }
}

class Vector <E> {
    private val minCapacityIncrement = 12
    var elements: Array<Any?>
    private var size = 0

    constructor() {
        this.elements = arrayOf()
    }

    constructor(initialCapacity: Int) {
        if (initialCapacity > 0) {
            this.elements = Array(initialCapacity) { i -> null }
        } else if (initialCapacity == 0) {
            this.elements = emptyArray()
        } else {
            throw IllegalArgumentException("Illegal Capacity: $initialCapacity")
        }
    }

    private fun newCapacity(currentCapacity: Int): Int {
        val increment = if (currentCapacity < minCapacityIncrement / 2)
            minCapacityIncrement / 2
        else
            currentCapacity shr 1
        return currentCapacity + increment
    }

    private fun throwIndexOutOfBoundsException(index: Int, size: Int): IndexOutOfBoundsException {
        throw IndexOutOfBoundsException("Invalid index $index, size is $size")
    }

    fun add(element: E): Boolean {
        var a = elements
        val s = size
        if (s == a.size) {
            val newArray = arrayOfNulls<Any>(s +
                if (s < minCapacityIncrement / 2)
                    minCapacityIncrement
                else
                    s shr 1)
            System.arraycopy(a, 0, newArray, 0, s)
            a = newArray
            elements = a
        }
        a[s] = element
        size = s + 1
        return true
    }

    fun add(index: Int, element: E) {
        // TODO
    }

    fun get(index: Int): E? {
        // TODO
        return null
    }

    fun set(index: Int, element: E): E? {
        // TODO
        return null
    }

    fun remove(index: Int): E? {
        // TODO
        return null
    }

    fun remove(element: E): Boolean {
        // TODO
        return false
    }

}