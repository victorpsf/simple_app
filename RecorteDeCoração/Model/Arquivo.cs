using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecorteDeCoração.Model
{
  internal class Arquivo
  {
    #region Atributos
    /// <summary>
    ///     @params { id_file } serve para quando o arquivo for lido no banco de dados, para facilitar a manipulação do mesmo
    ///     dentro das referências a ponteiros e etc.
    ///     @params { name_file, type_file } informações necessarias para criação dos respectivos arquivos.
    ///     @params { length_file } serve para aprensetar em form o tamanho de cada um dos arquivos sem necessariamente puxa-los do banco de dados
    ///     @obs: puxar os arquivos de dados só pode ser feito mediante a escolha, para evitar de carregar inumeros arquivos 
    ///           e ficar com eles em memoria.
    /// </summary>
    private int id;
    private string nome;
    private string extensao;
    private long tamanho;
    private byte[] binario;
    #endregion

    #region Contrutor
    public Arquivo() {
    }

    public Arquivo(string nome, string extensao, long tamanho, byte[] binario) : this() {
      this.nome = nome;
      this.extensao = extensao;
      this.tamanho = tamanho;
      this.binario = binario;
    }

    public Arquivo(int id, string nome, string extensao, long tamanho, byte[] binario) : this(nome, extensao, tamanho, binario) {
      this.id = id;      
    }

    #endregion

    #region propriedades
    public int Id
    {
      get { return this.id; }
      set { this.id = value; }
    }

    public string Nome
    {
      get { return this.nome; }
      set { this.nome = value; }
    }

    public string Extensao
    {
      get { return this.extensao; }
      set { this.extensao = value; }
    }

    public long Tamanho
    {
      get { return this.tamanho; }
      set { this.tamanho = value; }
    }

    public byte[] Binario
    {
      get { return this.binario; }
      set { this.binario = value; }
    }
    #endregion
  }
}
