# Xamarin.Forms-to-Arduino-over-Bluetooth
A complete mobile cross-platform xamarin app architecture with basic bluetooth implementations to Arduino Bluetooth communication.


This toturial is meant to demonstrate architectural guidelines and provide a fast start up code for bluetooth.


Each platform has specific Interfaces and implementations for Bluetooth communication, therefor, in order to achieve flexible and reusable code, a OOP design is mandatory.

Design Notes:
This code is meant as a bootstrap for fast start up, it is by no means idealy written and is supposed to be edited and changed according to youre project.

The entire project architecture:
 ![](Tutorial_Images/ArduinoApp_The_project_with_unimplemented.png)

Let's go over the diagram.
The Blue sqaure are the classes implemented in te common logic. The yellow squares are the android parts, and in red the IOS(currently not implemented)
As the diagram shows, most of the code is implemented in the shared logic part of the project(Blue squares). Whereas the android has only the MainActivity(only couple lines of code added to this part of the code), and the AndroidBluetoothClient in which the implementing for the domain specific communication is implemented.

The project has two main parts which we'll be explained seperatly:
The first is the BluetoothClient.

# --- Under Construction --- 

Basic flow:
 ![](Tutorial_Images/ArduinoApp_Basic_flow.png)

Bluetooth further explantion:
 ![](Tutorial_Images/ArduinoApp_Bluetooth.png)

Whole program - send and receive flow example:
 ![](Tutorial_Images/ArduinoApp_Send_Receive_Example.png)

