/// <summary>
/// Classe responsável por parametrizar o objeto Comodo existente no sistema
/// </summary>
public class Room
{
    public string idRealty;
    public string idRoom;
    public string name;
    public string urlPicture;
    public string urlPicture360;
    public string description;
    public int widthPicture360;
    public int heightPicture360;

    public Room()
    {
    }

    public Room(string idRealty, string idRoom, string name, string urlPicture, string urlPicture360, string description, int widthPicture360, int heightPicture360)
    {
        this.idRealty = idRealty;
        this.idRoom = idRoom;
        this.name = name;
        this.urlPicture = urlPicture;
        this.urlPicture360 = urlPicture360;
        this.description = description;
        this.widthPicture360 = widthPicture360;
        this.heightPicture360 = heightPicture360;
    }
}
