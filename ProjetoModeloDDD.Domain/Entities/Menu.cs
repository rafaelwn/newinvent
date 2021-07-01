

namespace ProjetoModeloDDD.Domain.Entities
{
    public class Menu
    {
        public int MenuId { get; set; }
        public int MenuId_Pai { get; set; }
        public int MenuId_Filho { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string CaminhoImagem { get; set; }
        public string Link { get; set; }
        public bool Situacao {get; set;}
    }
}
