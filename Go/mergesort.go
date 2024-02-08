package main

import "sync"

func merge(s []int, middle int) {
	// todo
}

func sequentialMergesort(s []int) {
	// todo
}

func parallelMergesortV1(s []int) {
	if len(s) <= 1 {
		return
	}

	middle := len(s) / 2

	var wg sync.WaitGroup
	wg.Add(2)

	go func() {
		defer wg.Done()
		parallelMergesortV1((s[:middle]))
	}()

	go func() {
		defer wg.Done()
		parallelMergesortV1((s[middle:]))
	}()

	wg.Wait()
	merge(s, middle)
}

const max = 2048

func parallelMergesortV2(s []int) {
	if len(s) <= 1 {
		return
	}

	if len(s) <= max {
		sequentialMergesort(s)
	} else {
		middle := len(s) / 2

		var wg sync.WaitGroup
		wg.Add(2)

		go func() {
			defer wg.Done()
			parallelMergesortV1((s[:middle]))
		}()

		go func() {
			defer wg.Done()
			parallelMergesortV1((s[middle:]))
		}()

		wg.Wait()
		merge(s, middle)
	}
}
