using System;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;

using RecorteDeCoração.Interfaces;

namespace RecorteDeCoração.Source
{
  class FileController
  {
    public static bool Exists(string path)
    {
      bool exists = false;

      try
      {
        exists = File.Exists(path);
      }

      catch (Exception error)
      {
        LogController.WriteException(error);
      }

      return exists;
    }

    public static bool NotExists(string path)
    {
      return !(FileController.Exists(path));
    }

    public static bool Write(string path, string content, char mode = 'a')
    {
      bool success = false;

      try
      {
        switch (mode)
        {
          case 'w':
            File.WriteAllText(path, content);
            break;
          case 'a':
          default:
            File.AppendAllText(path, content);
            break;
        }
        success = true;
      }

      catch (Exception error)
      {
        LogController.WriteException(error);
      }

      return success;
    }

    public static string Read(string path)
    {
      try
      {
        return File.ReadAllText(path);
      }

      catch (Exception error)
      {
        LogController.WriteException(error);
        return "";
      }
    }

    public static bool Create(string path)
    {
      try
      {
        Directory.CreateDirectory(path);
        return true;
      }

      catch (Exception error)
      {
        LogController.WriteException(error);
        return false;
      }
    }

    #region Funcoes
    /// <summary>
    ///     faz a verificação do arquivo.
    /// </summary>
    /// <param name="path"></param>
    /// <returns>vetor de string com 3 posições</returns>
    public static ArquivoInfo FileInfo(string path)
    {
      return new ArquivoInfo(path);
    }

    /// <summary>
    ///     retorna binario da imagem.
    /// </summary>
    /// <param name="path"></param>
    /// <returns></returns>
    public static byte[] ByteImage(string path)
    {
      try
      {
        Bitmap bitm = new Bitmap(path);
        MemoryStream MS = new MemoryStream();

        bitm.Save(MS, ImageFormat.Bmp);
        byte[] foto = MS.ToArray();

        return foto;
      }

      catch (Exception error)
      {
        LogController.WriteException(error);
        return null;
      }
    }

    /// <summary>
    ///     retorna bitmap para apresentação de imagens e etc.
    /// </summary>
    /// <param name="path"></param>
    /// <returns>bitmap caso </returns>
    public static Bitmap GetBitMap(string path, int Width = 80, int Height = 80)
    {
      try
      {
        return FileController.BytesToBitmap(FileController.ByteImage(path), Width, Height);
      }

      catch (Exception error)
      {
        LogController.WriteException(error);
        return null;
      }
    }
    #endregion
    public static Bitmap BytesToBitmap(byte[] bytes, int Width = 80, int Height = 80) {
      try
      {
        MemoryStream MS = new MemoryStream(bytes);
        Image img = Image.FromStream(MS);

        Bitmap bitm = new Bitmap(img, Width, Height);
        return bitm;
      }

      catch (Exception error)
      {
        LogController.WriteException(error);
        return null;
      }
    }
  }

}
