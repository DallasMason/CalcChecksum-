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
```
---

## Usage
```bash
./pa02 inputFilename.txt checksumSize
```
inputFilename.txt: The name of the input text file (must exist).

checksumSize: One of the following values: 8, 16, or 32.

---

## Example
```bash
./pa02 example.txt 16
```
---
## Output Format
-The program prints the input file content (padded with 'X' if needed) in 80-character lines.
-It then prints the computed checksum in hexadecimal format, along with the checksum size and the total number of characters processed.

## Sample Output
```bash
This is a sample ASCII file for testing the checksum calculator. It will be p
added with X's if required to make the total character count match the checksu
m unit size.

16 bit checksum is 4a2f for all 0080 chars
```
---

## File Structure
- pa02.c: The main C source file containing:
- File reading and argument validation.
- Checksum computation functions for 8, 16, and 32 bits.
- Padding logic and formatted display routines.
---

## Assumptions
- Input files are assumed to be ASCII-encoded.
- Maximum file size is limited to 1024 characters.
- No padding is added for 8-bit checksums.
- For 16-bit checksums, input length must be divisible by 2.
- For 32-bit checksums, input length must be divisible by 4

