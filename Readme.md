## Things to improve

### Behaviour
- When an invalid place command occurs, it is just ignored, with no indication to the user of why
- Output from failed placement is confusing (tile index starting at zero so it says cannot place at position 5, 5 for a board size of 5 for example)

### Testing
- Boundary testing (e.g. more extensive testing of place command - can we definitely not place the robot outside of the 5x5 grid?)

### Implementation
- Possibly excessive repetition and nesting of `CanExecute()` method