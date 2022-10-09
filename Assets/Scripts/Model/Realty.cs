/// <summary>
/// Classe responsável por parametrizar o objeto Imovel existente no sistema
/// </summary>
public class Realty
{
    public string idUser;
    public string idRealty;
    public string description;
    public string urlPicture;
    public string name;
    public double price;

    public Realty()
    {

    }

    public Realty(string idUser, string idRealty, string name, string description, string urlPicture, double price)
    {
        this.idUser = idUser;
        this.idRealty = idRealty;
        this.name = name;
        this.description = description;
        this.urlPicture = urlPicture;
        this.price = price;
    }
}
