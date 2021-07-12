using System.IO;
using System.Threading.Tasks;

namespace Aplicacao.Servicos
{
    public static class GerenciadorArquivo
    {
        public static async Task CriarArquivo(Stream stream, string path, string fileName)
        {
            Directory.CreateDirectory(path);
            using var fileStream = new FileStream(CombinarPath(path, fileName), FileMode.Create, FileAccess.ReadWrite);
            await stream.CopyToAsync(fileStream);
        }

        public static string DiretorioCorrente() => Directory.GetCurrentDirectory();
        public static string CombinarPath(string path1, string path2) => Path.Combine(path1, path2);
    }
}
