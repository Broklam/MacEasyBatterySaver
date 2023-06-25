package main

import (
	"bufio"
	"fmt"
	"os"
	"os/exec"
)

const (
	FAQ  = "Hi User\n\nUnfortunately, there is no quick way to turn on power saving mode from the desktop on macOS, and as the owner of a Mac on M1, I really wanted to do this. So I had the (perhaps strange) idea to write this program. The source code is in the public domain, and the program itself is far from elegant, as it requires a password and does the whole trick by opening a terminal.\n\nHowever, this does the job for me. Perhaps in the future, I would like to rewrite the program under Swift, but we'll see.\n\nI hope this program will make your life a little easier.\n\nWith love from rainy Aachen.\n\nB."
	INTR = "Greetings.\n\nHere is the list of available commands:\n\nTo turn ON power saving mode, type 'on' or '1'.\n\nTo turn power saving mode OFF, type 'off' or '0'.\n\nFor FAQ, type 'faq'"
)

func ExecuteCommand(command string) {
	cmd := exec.Command("sudo","pmset", "-a", "lowpowermode", command)
	cmd.Stdout = os.Stdout
	cmd.Stderr = os.Stderr

	err := cmd.Run()
	if err != nil {
		fmt.Printf("Command execution error: %s\n", err)
	}
}

func main() {
	fmt.Println(INTR)

	scanner := bufio.NewScanner(os.Stdin)

	for scanner.Scan() {
		userInput := scanner.Text()

		switch userInput {
		case "off":
			ExecuteCommand("0")
			return
		case "on", "1":
			ExecuteCommand("1")
			return
		case "0":
			ExecuteCommand("0")
			return
		case "faq":
			fmt.Println(FAQ)
		default:
			fmt.Println("It looks like you provided the wrong argument, try again")
		}
	}
}
