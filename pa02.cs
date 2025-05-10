/*============================================================================
| Assignment: pa02 - Calculate the checksum of an input file given:
| -> the name of the input file,
| -> the checksum size of either 8, 16, or 32 bits
| Author: Dallas Holevas-Mason
| Language: c
| To Compile: gcc -o pa02 pa02.c
| To Execute: c -> ./pa02 inputFilename.txt checksumSize
| where inputFilename.txt is the input file
| and checksumSize is either 8, 16, or 32
| Note:
| All input files are simple 8 bit ASCII input
| All execute commands above have been tested on Eustis
| Class: CIS3360 - Security in Computing - Spring 2025
| Instructor: McAlpin
| Due Date: 3/23/25
+===========================================================================*/
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#define MAX_INPUT_SIZE 1024 // Maximum buffer size for input data
// Function prototypes
int computeChecksum8(unsigned char *buffer, int size); // Compute 8-bit checksum
int computeChecksum16(unsigned char *buffer, int size); // Compute 16-bit checksum
int computeChecksum32(unsigned char *buffer, int size); // Compute 32-bit checksum
void modifyByteArray(char *inputString, int bitLength, unsigned char *resultArray,
int *finalLength); // Modify byte array with padding
int determinePadding(int initialLength, int bitLength); // Determine padding needed
void displayFormattedOutput(char *resultString); // Display output with 80 chars
per line
void modifyString(char *inputString, int bitLength, char *resultString); // Modify
string with padding
int main(int argc, char *argv[]) {
// Validate number of arguments
if (argc != 3) {
fprintf(stderr, "\nPlease provide the proper parameters.\nFirst Parameter
is the input file name, second is the size of the checksum.\n");
exit(1);
}
// Open file for reading
FILE *filePointer = fopen(argv[1], "r");
if (filePointer == NULL) {
fprintf(stderr, "\nFile %s does not exist\n", argv[1]);
exit(1);
}
// Parse checksum bit size and validate
int bitSize = atoi(argv[2]);
if (bitSize != 8 && bitSize != 16 && bitSize != 32) {
fprintf(stderr, "\nValid checksum sizes are 8, 16, or 32\n");
exit(1);
}
// Read input file into buffer
char inputBuffer[MAX_INPUT_SIZE];
int inputLength = 0;
while (fgets(inputBuffer + inputLength, MAX_INPUT_SIZE - inputLength,
filePointer)) {
inputLength = strlen(inputBuffer);
}
fclose(filePointer);
unsigned char byteBuffer[MAX_INPUT_SIZE];
int adjustedLength;
modifyByteArray(inputBuffer, bitSize, byteBuffer, &adjustedLength);
// Compute checksum based on bit size
int checksumValue;
if (bitSize == 8) {
checksumValue = computeChecksum8(byteBuffer, adjustedLength);
} else if (bitSize == 16) {
checksumValue = computeChecksum16(byteBuffer, adjustedLength);
} else {
checksumValue = computeChecksum32(byteBuffer, adjustedLength);
}
char modifiedString[MAX_INPUT_SIZE];
modifyString(inputBuffer, bitSize, modifiedString);
displayFormattedOutput(modifiedString);
// Display final checksum result
printf("\n%2d bit checksum is %4x for all %4d chars\n", bitSize, checksumValue,
adjustedLength);
return 0;
}
// Modify byte array to include padding with 'X' if necessary
void modifyByteArray(char *inputString, int bitLength, unsigned char *resultArray,
int *finalLength) {
int originalSize = strlen(inputString);
int paddingAmount = determinePadding(originalSize, bitLength);
*finalLength = originalSize + paddingAmount;
// Copy original bytes to result array
for (int i = 0; i < originalSize; i++) {
resultArray[i] = (unsigned char) inputString[i];
}
// Add padding if needed
if (paddingAmount > 0) {
for (int i = originalSize; i < *finalLength; i++) {
resultArray[i] = 'X'; // Padding character 'X'
}
}
}
// Compute 8-bit checksum by summing each byte
int computeChecksum8(unsigned char *buffer, int size) {
int checksum = 0;
for (int i = 0; i < size; i++) {
checksum += buffer[i];
}
return checksum & 0xFF; // Mask to 8 bits
}
// Compute 16-bit checksum by summing every two bytes
int computeChecksum16(unsigned char *buffer, int size) {
int checksum = 0;
for (int i = 0; i <= size - 2; i += 2) {
checksum += ((buffer[i] << 8) | buffer[i + 1]);
}
return checksum & 0xFFFF; // Mask to 16 bits
}
// Compute 32-bit checksum by summing every four bytes
int computeChecksum32(unsigned char *buffer, int size) {
int checksum = 0;
for (int i = 0; i <= size - 4; i += 4) {
checksum += ((buffer[i] << 24) | (buffer[i + 1] << 16) | (buffer[i + 2] <<
8) | buffer[i + 3]);
}
return checksum; // Mask to 32 bits if needed
}
// Determine the required padding based on bit size
int determinePadding(int initialLength, int bitLength) {
int length = initialLength;
int modulus = (bitLength == 32) ? 4 : 2;
int padding = 0;
while (length % modulus != 0) {
length++;
padding++;
}
return (bitLength > 8) ? padding : 0; // No padding for 8 bits
}
// Modify string with padding character 'X'
void modifyString(char *inputString, int bitLength, char *resultString) {
int originalSize = strlen(inputString);
int paddingAmount = determinePadding(originalSize, bitLength);
int newSize = originalSize + paddingAmount;
strcpy(resultString, inputString);
// Add padding if needed
if (paddingAmount > 0) {
for (int i = originalSize; i < newSize; i++) {
resultString[i] = 'X';
}
}
resultString[newSize] = '\0'; // Null terminate the string
}
// Display formatted output with 80 characters per line
void displayFormattedOutput(char *resultString) {
int length = strlen(resultString);
for (int i = 0; i < length; i++) {
printf("%c", resultString[i]);
if ((i + 1) % 80 == 0) { // New line after 80 characters
printf("\n");
}
}
if (length % 80 != 0) {
printf("\n");
}
}
/*=============================================================================
| I Dallas Holevas-Mason (da869902) affirm that this program is
| entirely my own work and that I have neither developed my code together with
| any another person, nor copied any code from any other person, nor permitted
| my code to be copied or otherwise used by any other person, nor have I
| copied, modified, or otherwise used programs created by others. I acknowledge
| that any violation of the above terms will be treated as academic dishonesty.
+=============================================================================*/