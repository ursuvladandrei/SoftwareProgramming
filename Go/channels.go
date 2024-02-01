package main

import "fmt"

func main() {
	messages := make(chan string)

	go func() { message <- "ping" }()

	msg := <- message
	fmt.Println(msg)
}