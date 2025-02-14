
class Person (val firstName: String, val lastName: String, val age:Int?) {
    init {
        require(firstName.trim().length > 0) { "Invalid firstName argument." }
        require(lastName.trim().length > 0) { "Invalid lastName argument." }
        if (age != null) {
            require(age >= 0 && age < 150) { "Invalid age argument." }
        }
    }
}

class A {
    private val somefield: Int = 1
    inner class B {
        private val somefield: Int = 1
        fun foo(s: String) {
            println("Field <somefield> from B" + this.somefield)
            println("Field <somefield> from B" + this@B.somefield)
            println("Field <somefield> from A" + this@A.somefield) 
        }
    }
}

interface Document {
    val version: Long
    val size: Long
    val name: String
    get() = "NoName"

    fun save(input: InputStream)
    fun load(stream: OutputStream)
    fun getDescription(): String {
        return "Document $name has $size bytes"
    }
}

class DocumentImpl: Document {
    override val version: Long
    get() = 0
    
    override val size: Long
    get() = 0

    override fun save(input: InputStream) {}
    override fun load(stream: OutputStream) {}
}


fun main(args: Array<String>) {
    println("Hello, World!")
    val person1 = Person("Alex", "Smith", 29)
    println("${person1.firstName}")
}