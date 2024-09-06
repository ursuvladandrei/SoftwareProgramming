#include <stdio.h>
#include <stdlib.h>
#include <string.h>

#define ERROR 0
#define BUFFER_SIZE 512
#define NO_KEYWORD_FOUND -1
#define KEYWORD_ONE_FOUND_FIRST 1
#define KEYWORD_TWO_FOUND_FIRST 2

int parseFile(char* file_name)
{
    int return_value = ERROR;
    FILE* file_pointer = 0;
    char* buffer = 0;

    if (file_name != NULL)
    {
        if (file_pointer = fopen(file_name, "r"))
        {
            if (buffer = malloc(BUFFER_SIZE))
            {
                /* parse file content */
                return_value = NO_KEYWORD_FOUND;
                while (fgets(buffer, BUFFER_SIZE, file_pointer) != NULL)
                {
                    if (strcmp("KEYWORD_ONE\n", buffer) == 0)
                    {
                        return_value = KEYWORD_ONE_FOUND_FIRST;
                        break;
                    }
                    if (strcmp("KEYWORKD_TWO\n", buffer) == 0)
                    {
                        return_value = KEYWORD_TWO_FOUND_FIRST;
                        break;
                    }
                }
                free(buffer);
            }
            fclose(file_pointer);
        }
    }
    return return_value;
}

/* 
void someFunction()
{
    if (!allocateResource1())
    {
        goto cleanup1;
    }
    if (!allocateResource2())
    {
        goto cleanup2;
    }
    mainProgram();

cleanup2:
    cleanupResource2();
cleanup1:
    cleanupResource1();
}
*/

typedef struct
{
    FILE* file_pointer;
    char* buffer;
}FileParser;

int parseFile(char* file_name)
{

}

int searchFileForKeywords(FileParser* parser)
{

}

FileParser* createParser(char* file_name)
{

}

void cleanupParser(FileParser* parser)
{
    
}


void main() {
    printf("hello, world\n");
}