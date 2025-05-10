# Checksum Calculator (pa02)

## Overview

This C program calculates the checksum of a given input file using either 8-bit, 16-bit, or 32-bit checksums. The program reads an ASCII text file, pads it if necessary, and computes the checksum according to the user-specified bit size.

This project was developed for **CIS3360 - Security in Computing (Spring 2025)** at the University of Central Florida.

---

## Features

- Supports 8-bit, 16-bit, and 32-bit checksum calculations.
- Handles file reading and padding as required.
- Formats and displays input and checksum clearly.
- Designed for 8-bit ASCII input files.

---

## Compilation

To compile the program, use `gcc`:

```bash
gcc -o pa02 pa02.c
