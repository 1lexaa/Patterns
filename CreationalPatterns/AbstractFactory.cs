using System;

namespace DesignPatterns.CreationalPatterns
{
   internal class AbstractFactory
    {
            public void Show()
            {
                    ICrypterAbstractFactory factory = new DSTUFactory();
                    ICryptoHasher hasher = factory.GetHasher();
                    Console.WriteLine(hasher.Hash("test"));
                    ICryptoCipher cipher = factory.GetCipher();
                    Console.WriteLine(cipher.Cipher("test"));
                    ICryptoDecipher decipher = factory.GetDecipher();
                    Console.WriteLine(decipher.Decipher("test"));


                    ICrypterAbstractFactory factory1 = new AESFactory();
                    ICryptoHasher hasher1 = factory1.GetHasher();
                    Console.WriteLine(hasher1.Hash("test"));
                    ICryptoCipher cipher1 = factory1.GetCipher();
                    Console.WriteLine(cipher1.Cipher("test"));
                    ICryptoDecipher decipher1 = factory1.GetDecipher();
                    Console.WriteLine(decipher1.Decipher("test"));

            }
    }

#region ICrypto
interface ICryptoHasher
{
    public string Hash(string input);
}

interface ICryptoCipher
{
    string Cipher(string input);
}

interface ICryptoDecipher
{
    string Decipher(string input);
}

    interface ICrypterAbstractFactory
    {
        ICryptoHasher GetHasher();
        ICryptoCipher GetCipher();
        ICryptoDecipher GetDecipher();
    }

#endregion 
/////////////////////////////////////////////////////////////


#region DSTU
class DSTUHasher : ICryptoHasher
{
    public string Hash(string input)
    {
        return $"Kupina hash of '{input}' ";
    }
}


class DSTUCipher : ICryptoCipher
{
    public string Cipher(string input)
    {
        return $"Kalina cipher of '{input}' ";
    }
}


class DSTUDecipher : ICryptoDecipher
{
    public string Decipher(string input)
    {
        return $"Kalina decipher of '{input}' ";
    }
}


    class DSTUFactory : ICrypterAbstractFactory
    {
        public ICryptoCipher GetCipher()
        {
            return new DSTUCipher();
        }

        public ICryptoDecipher GetDecipher()
        {
            return new DSTUDecipher();
        }

        public ICryptoHasher GetHasher()
        {
            return new DSTUHasher();
        }
    }
#endregion


#region AES

class AESHasher : ICryptoHasher
{
    public string Hash(string input)
    {
        return "SHA-1 hash of " + input;

    }
}

class AESCipher : ICryptoCipher
{
 public string Cipher(string input)
 {
     return "AES cipher of" + input;
 }
}

class AESDecipher : ICryptoDecipher
{
 public string Decipher(string input)
 {
     return "AES decipher of " + input;
 }
}

class AESFactory : ICrypterAbstractFactory
{
    public ICryptoHasher GetHasher()
    {
        return new AESHasher();
    }
    public ICryptoCipher GetCipher()
    {
        return new AESCipher();
    }
    public ICryptoDecipher GetDecipher()
    {
        return new AESDecipher();
    }
}

#endregion
}

/* Абстрактная фабрика - фабрика фабрик
Простая фабрика - создает конкретные объекты
Если конкретные объекты связаны , то переключение на новую связку
- это использоание новой фабрики . Абстрактная фабрика - фабрика , создающая конкретную 
фабрику
Crypto { Hash, Encipher , Decipher }
AES { SHA , Cipher , Decipher }
DSTU { KUPINA ,KalinaC, KalinaD }


*/