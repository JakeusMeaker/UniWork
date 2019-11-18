 from Crypto.Cipher import AES
from Crypto.Random import get_random_bytes

#Caesar Cipher
letters = 'ABCDEFGHIJKLMNOPQRSTUVWXYZ'


CaeserCipher = False
XORCipher = True
AESCipher = False
AESCipherEncrypt = False
AESCipherDecrypt = False


if(CaeserCipher):
    message = input("Phrase to Decrypt")
    for key in range(len(letters)):
        translated = ''

        for symbol in message:
            if symbol in letters:
                num = letters.find(symbol)
                num = num - key

                if num < 0:
                    num = num + len(letters)

                translated = translated + letters[num]
            else:
                translated = translated + symbol

        print('Key #%s: %s' % (key, translated))

#XOR Cipher
#the came code is used to encryot and decrypt
if(XORCipher):
    message2 = str(input("Phrase to encrypt/decrypt:"))
    def encryptDecrypt(inpString):

        xorKey = 'P'

        length = len(inpString)

        for i in range(0,length):
            print(inpString[i], end="")
            inpString = (inpString[:i] + chr(ord(inpString[i]) ^ ord(xorKey)) + inpString[i + 1:])

        return inpString

    if __name__ == '__main__':
        sampleString = message2

        print("Encrypted String: ", end = "")
        sampleString = encryptDecrypt(sampleString)
        print("\n")

        print("Decrypted String: ", end = "")
        encryptDecrypt(sampleString)


#AES Cypher
#Encryption

if(AESCipher):
    data = get_random_bytes(16)
    print("Random no. for encryption: " + str(data))

    key = b'Sixteen byte key'
    cipher = AES.new(key, AES.MODE_EAX)

    nonce = cipher.nonce
    ciphertext, tag = cipher.encrypt_and_digest(data)



