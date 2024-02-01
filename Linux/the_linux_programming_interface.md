# The Linux Programming Interface

# 7 Memory Allocation - 139
# 7.1 Allocating Memory on the Heap
int brk(void *end_data_segment); // increases the program break
void *sbrk(intptr_t increment);
void *malloc(size_t size);
void free(void *ptr);

# to avoid allocation errors:
# don't touch any bytes outside the range of the allocated block
# it is an error to free the same piece of allocated memory twice
# never call free() with a pointer value that wasn't obtained by a call
# to one of the functions in the malloc package
# long-running program + repeatedly allocates memory => free the memory

# tools and libraries for malloc debugging
mtrace(), muntrace()
mcheck(), mprobe()
MALLOC_CHECK_ environment variable

# nonstandard functions that can be used to monitor and control the allocation
# of memory by functions in the malloc package:
mallopt()
mallinfo()

# other methods of allocating memory on the heap:
void *calloc(size_t numitems, size_t size);
void *realloc(void *ptr, size_t size);
void *memalign(size_t boundary, size_t size); // allocate memory starting at
// an address aligned at a specified power-of-two boundary

# 7.2 Allocating Memory on the Stack - 150
# TODO