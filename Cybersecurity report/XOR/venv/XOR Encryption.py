toDecode = input("To Encode/Decode")

def encryptDecrypt(inpString):

    xorKey = "p"

    length = len(inpString)

    for i in range(length):

        inpString = (inpString[:i] + chr(ord(inpString[i]) ^ ord(xorKey)) + inpString[i + 1:])
        print(inpString[i], end = "")

    return inpString

if __name__ == '__main__':
    sampleString = toDecode

    #encrypt string
    print("Encrypted String: ", end = "")
    sampleString = encryptDecrypt(sampleString)
    print("\n")

    #decrypt string
    print("Decrypted String: ", end = "")
    encryptDecrypt((sampleString))