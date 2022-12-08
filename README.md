# Logic Circuitry

Learning about computer engineering in my University Class. I thought
it might be a fun project to try and simulate the logical gates in a
computer program.

# Fundamentals
When designing a circuit, there are two states. ON, and OFF. My simulator
represents these two states with grey for OFF state, and a magenta color for the
ON state.

There are three types of logic gates that are necessary for all circuits. All other 
logic gates are some combination of these three. The three gates are NOT, which inverts
the state, NAND, which takes two inputs and outputs ON if at least one is OFF, and
NOR, which takes two inputs and outputs OFF if at least one is ON.

Currently the program has functionality to simulate all three of these gates.
It uses a recursive algorithm that determines the ON/OFF state at each point
and displays it using colored wires.

![Screen_Shot_2022-02-17_at_8 09 27_PM](https://user-images.githubusercontent.com/20736357/206360633-227450e8-d80a-459c-9c05-6e7f2e3a9577.png)
