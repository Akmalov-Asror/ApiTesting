namespace postgress.Encryptors;

public interface IEncryptor
{
    string Encrypt(string data, string? key = "Juggernaut,SacredWarrior,Ymir,Io");
    string Decrypt(string data, string? key = "Juggernaut,SacredWarrior,Ymir,Io");
}