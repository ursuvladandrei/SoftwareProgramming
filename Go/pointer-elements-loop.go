package main

import "fmt"

type Customer struct {
	ID string
	Balance float64
}

type Store struct {
	m map[string]*Customer
}

func (s *Store) storeCustomers(customers []Customer) {
	for _, customer := range customers {
		current := customer
		s.m[current.ID] = &current
	}
}

func main() {

	var s Store
	s.m = make(map[string]*Customer)

	s.storeCustomers([]Customer{
		{ID: "1", Balance: 10},
		{ID: "2", Balance: -10},
		{ID: "3", Balance: 0},
	})

	for key, value := range s.m {
		fmt.Println("key:", key)
		fmt.Printf("%+v\n", value)
	}

	fmt.Println("Hello, world")
}