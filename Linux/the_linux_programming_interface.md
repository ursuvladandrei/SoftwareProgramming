## The Linux Programming Interface

### 7 Memory Allocation - 139
#### 7.1 Allocating Memory on the Heap
```
int brk(void *end_data_segment); // increases the program break
void *sbrk(intptr_t increment);
void *malloc(size_t size);
void free(void *ptr);
```

- to avoid allocation errors:
    - don't touch any bytes outside the range of the allocated block
    - it is an error to free the same piece of allocated memory twice
    - never call free() with a pointer value that wasn't obtained by a call
    - to one of the functions in the malloc package
    - long-running program + repeatedly allocates memory => free the memory

- tools and libraries for malloc debugging
```
mtrace(), muntrace()
mcheck(), mprobe()
MALLOC_CHECK_ environment variable
```

- nonstandard functions that can be used to monitor and control the allocation
- of memory by functions in the malloc package:
```
mallopt()
mallinfo()
```

- other methods of allocating memory on the heap:
```
void *calloc(size_t numitems, size_t size);
void *realloc(void *ptr, size_t size);
void *memalign(size_t boundary, size_t size); // allocate memory starting at
// an address aligned at a specified power-of-two boundary
```

#### 7.2 Allocating Memory on the Stack - 150
- to increase the stack frame and get memory from the stack
```
void *alloca(size_t size);
```
- should not call free on memory allocated using alloca


### 8 Users and Groups - 153

#### 8.1 The Password File: /etc/passwd
```
mtk:x:1000:100:Michael Kerrisk:/home/mtk:/bin/bash
```
- Login name
- Encrypted password
- User ID (UID)
- Group ID (GID)
- Comment
- Home directory
- Login shell

#### 8.2 The Shadow Password File: /etc/shadow
#### 8.3 The Group File: /etc/group
```
users:x:100:alex,michael
```
- Group name
- Encrypted password
- Group ID
- User list

#### 8.4 Retrieving User and Group Information
- retrieving records from the password file
```
struct passwd *getpwnam(const char *name);
struct passwd *getpwuid(uid_t uid);
```
- retrieving records from the group file
```
struct group *getgrnam(const char *name);
struct group *getgrgid(gid_t gid);
```
- common usages is to implement: 
*getNameFromId(), userIdFromName(), groupNameFromId(), groupIdFromName()*

- scanning all records in the password and group files
```
struct passwd *getpwnet(void);
void setpwent(void);
void endpwent(void);

struct passwd *pwd;

while ((pwd = getpwent()) != NULL)
    printf("%s %ld\n", pwd->pw_name, (long) pwd->pw_uid);

endpwent();
```

- retrieving records from the shadow password file
```
struct spwd *getspname(const char *name);
struct spwd *getspent(void);
void setspent(void);
void endspent(void);
```

- the *crypt()* function encrypts a password in the same manner as the standard
login program, which is useful for programs that need to authenticate users
```
char *crypt(const char *key, const char *salt);
```

#### 8.5 Password Encryption and User Authentication

### 9 Process Credentials