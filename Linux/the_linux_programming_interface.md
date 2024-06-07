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

#### 8.5 Password Encryption and User Authentication
- the *crypt()* function encrypts a password in the same manner as the standard
login program, which is useful for programs that need to authenticate users
```
char *crypt(const char *key, const char *salt);
```

### 9 Process Credentials - 167

#### 9.1 Read User ID and Read Group ID
- when a new process is created, it inherits these identifiers from its parents

#### 9.2 Effective User ID and Effective Group ID
- a process whose effective user ID is 0 has all the privileges of the superuser (privileged process)
- normally, the effective user and group IDs have the same values as the corresponding read IDs

#### 9.3 Set-User-ID and Set-Group-ID Programs
- a set-user-ID program allows a process to gain privileges it would not normally have,
by setting the process's effective user ID to the same value as the user ID (owner) of
the executable file (similar for set-group-ID)
```
su
ls -l prog
chmod u+s prog      // turn on set-user-ID permission bit
chmod g+s prog      // turn on set-group-ID permission bit
```
- when a set-user-ID program is run, the kernel sets the effective user ID of the 
process to the same as the user ID of the executable file

#### 9.4 Saved Set-User-ID and Saved Set-Group-ID
- these allow a program to temporarily drop and regain whatever privileges are
associated with the user ID of the execed file

#### 9.5 File-System User ID and File-System Group ID
- pretty much the same as effective user and group IDs

#### 9.6 Supplementary group IDs
- not worth going into

#### 9.7 Retrieving and Modifying Process Credentials
- retrieving and modifying real, effective, and saved set IDs
```
uid_t getuid(void);     // real
uid_t geteuid(void);    // effective 
gid_t getgit(void);
git_t getegit(void);
int setuid(uid_t uid);
int setgit(gid_t gid);
int seteuid(uid_t euid);
int setegid(gid_t egid);
int setreuid(uid_t ruid, uid_t euid); // real + effective
int setregid(gid_t rgid, gid_t egid); // real + effective
int getresuid(uid_t *ruid, uid_t *euid, uid_t *suid); // real + effective + saved
int getresgid(gid_t *rgid, gid_t *egid, gid_t *sgid);
int setresuid(uid_t ruid, uid_t euid, uid_t suid);
int setresgid(gid_t rgid, gid_t egid, gid_t sgid);
```

### 10 Time - 185

### 11 System Limits and Options