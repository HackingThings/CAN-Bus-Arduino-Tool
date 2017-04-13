# CAN-pipe
A tool for creating a windows named pipe to capture CAN bus traffic using wireshark.

# Requirements:
- An arduino UNO or similar device.
- An MCP2515 based arduino shield.
- knowledge on how to prgram an arduino.
- a windows based computer.


# THINGS YOU NEED TO KNOW
1. The code was written using visual studio 2017 community edition.
2. This solution has an arudino sketch designed for use with an UNO but can be modified to fit any other arduino, be aware of the correct pin to use for your choice of CAN bus shield.
3. When using wireshark, you might want to use 'wireshark legacy' as that is the only option to use that supports saving of named pipes in windows.

