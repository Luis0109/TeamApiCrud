namespace TeamApi.Models {
    public class Time {

        public int Id { get; set; }
        public string Nome { get; private set; }

        public int Numero { get; set; }
        public string Team { get; set; }

        public string Posicao { get; set; }

        public Time(string nome, int numero, string team, string posicao) {
            Nome = nome;
            Numero = numero;
            Team = team;
            Posicao = posicao;

        }


        public void UpdateInfo(string nome, int numero, string team, string posicao) {
            Nome = nome;
            Numero = numero;
            Team = team;
            Posicao = posicao;
        }
    }

}
