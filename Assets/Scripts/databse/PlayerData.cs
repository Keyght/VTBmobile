
using System.Collections.Generic;

public class PlayerData 
{
    public struct InvesyingStatus
    {
        public int data;
        public int count;
    }

    public string name;
    public string sex;
    public string type_work;
    public string type_fee;

    public int data;

    public List<InvesyingStatus> contribution=new List<InvesyingStatus>();
    public List<InvesyingStatus> Bonds_Gos = new List<InvesyingStatus>();
    public List<InvesyingStatus> Bonds_Muc = new List<InvesyingStatus>();
    public List<InvesyingStatus> Bonds_Kom = new List<InvesyingStatus>();


    public PlayerData(string _name,string _sex, string _work, string _fee)
    {
        name = _name;
        sex = _sex;
        type_work = _work;
        type_fee = _fee;
        data = 0;


    }


}
