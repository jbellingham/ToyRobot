## Things to improve

### Behaviour
- When an invalid place command occurs, it is just ignored, with no indication to the user of why
- Output from failed placement is confusing (tile index starting at zero so it says cannot place at position 5, 5 for a board size of 5 for example)

### Testing
- Boundary testing (e.g. more extensive testing of place command - can we definitely not place the robot outside of the 5x5 grid?)
- Add testing of file input parsing
- Colocated test files (e.g. LeftTests.cs in the same directory as Left.cs -- kindof a pain to do in .Net because reasons)
- Mutation testing - are our tests testing what we think they're testing?

### Implementation
- Possibly excessive repetition and nesting of `CanExecute()` method
- Law of demeter violations around robot position
- File reading and command parsing is gross, error prone, not extensible...
- Error messaging is inline - probably could separate out (maybe a command's `Execute` method has a return type that contains possible error messages?)
- Can I make board size private somehow?
- Add more comments - particularly around position facing