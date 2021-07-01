
using System.Collections.Generic;
using System.Linq;
using ProjetoModeloDDD.Domain.Entities.Inventario;
using ProjetoModeloDDD.Domain.Interfaces.Repositories.Inventario;
using ProjetoModeloDDD.Domain.Interfaces.Services.Inventario;
using System.IO;
using System;
using System.Data;
using System.Data.SqlClient;
using System.ComponentModel;


namespace ProjetoModeloDDD.Domain.Services.Inventario
{
    public class ProdutoImportacaoService : ServiceBase<ProdutoImportacao>, IProdutoImportacaoService
    {

        private readonly IProdutoImportacaoRepository _produtoImportacaoRepository;
        private readonly IItemControleInventarioRepository _itemControleInventarioRepository;

        public ProdutoImportacaoService(IProdutoImportacaoRepository produtoImportacaoRepository, IItemControleInventarioRepository itemControleInventarioRepository)
            :base(produtoImportacaoRepository)
        {
            _produtoImportacaoRepository = produtoImportacaoRepository;
            _itemControleInventarioRepository = itemControleInventarioRepository;
        }   

        public IEnumerable<ProdutoImportacao> ImportarTxt_Ok(string CaminhoArquivoImportacao)
        {
            int linha = 0;
            string valorlinha = string.Empty;
            string colunaAtual = string.Empty;
            string valorAtual = string.Empty;

            try
            {
                StreamReader strProdutosImportacao = new StreamReader(CaminhoArquivoImportacao);
                ProdutoImportacao objProdutoImportacao = new ProdutoImportacao();

                

                // LIMPAR A TABELA
                _produtoImportacaoRepository.RemoveAll();

                while (strProdutosImportacao.Peek() > -1)
                {
                    linha++;

                    valorlinha = strProdutosImportacao.ReadLine();                    

                    colunaAtual = "Data"; valorAtual = "DateTime.Now";
                    objProdutoImportacao.Data = DateTime.Now; // TESTE - RETIRAR
                    colunaAtual = "NumeroLoja"; valorAtual = valorlinha.Substring(0, 6);
                    objProdutoImportacao.NumeroLoja = Convert.ToInt32(valorAtual);
                    colunaAtual = "CodigoEan"; valorAtual = valorlinha.Substring(12, 13);
                    objProdutoImportacao.CodigoEan = Convert.ToInt64(valorAtual);
                    colunaAtual = "NomeProduto"; valorAtual = valorlinha.Substring(25, 50);
                    objProdutoImportacao.NomeProduto = valorAtual;

                    colunaAtual = "PrecoUnitario"; valorAtual = valorlinha.Substring(75, 7) + "," + valorlinha.Substring(82, 2);
                    objProdutoImportacao.PrecoUnitario = Convert.ToDecimal(valorAtual);

                    colunaAtual = "PrecoVendaUnitario"; valorAtual = valorlinha.Substring(84, 7) + "," + valorlinha.Substring(91, 2);
                    objProdutoImportacao.PrecoVendaUnitario = Convert.ToDecimal(valorAtual);

                    colunaAtual = "Quantidade"; valorAtual = valorlinha.Substring(93, 5) + "," + valorlinha.Substring(98, 3);
                    objProdutoImportacao.Quantidade = Convert.ToDecimal(valorAtual);

                    colunaAtual = "DepartamentoId"; valorAtual = valorlinha.Substring(101, 8);
                    objProdutoImportacao.DepartamentoId = Convert.ToInt32(valorAtual);
                    colunaAtual = "NomeDepartamento"; valorAtual = valorlinha.Substring(109, 50);
                    objProdutoImportacao.NomeDepartamento = valorAtual;
                    colunaAtual = "SecaoId"; valorAtual = valorlinha.Substring(159, 8);
                    objProdutoImportacao.SecaoId = Convert.ToInt32(valorAtual);
                    colunaAtual = "NomeSecao"; valorAtual = valorlinha.Substring(167, 50);
                    objProdutoImportacao.NomeSecao = valorAtual;
                    colunaAtual = "GrupoId"; valorAtual = valorlinha.Substring(217, 8);
                    objProdutoImportacao.GrupoId = Convert.ToInt32(valorAtual);
                    colunaAtual = "NomeGrupo"; valorAtual = valorlinha.Substring(225, 50);
                    objProdutoImportacao.NomeGrupo = valorAtual;
                    colunaAtual = "SubGrupoId"; valorAtual = valorlinha.Substring(275, 8);
                    objProdutoImportacao.SubGrupoId = Convert.ToInt32(valorAtual);
                    colunaAtual = "NomeSubGrupo"; valorAtual = valorlinha.Substring(283, 8);
                    objProdutoImportacao.NomeSubGrupo = valorAtual;

                    colunaAtual = "Identificador"; valorAtual = valorlinha.Substring(100, 8);
                    objProdutoImportacao.Identificador = Convert.ToInt32(valorAtual);                    
              
                    _produtoImportacaoRepository.Add(objProdutoImportacao);

                    objProdutoImportacao = new ProdutoImportacao();

                }
            }
            catch (Exception ex)
            {
                // PENDENTE 18/02/2015 - 17:18
                // INCLUIR ERRO NO LOG GERAL
                // INCLUIR ERRO NA TABELA DE ERRO DE IMPORTACAO
                throw new ArgumentException("Erro na linha: " + linha.ToString() + " *** Campo : " + colunaAtual + " *** Valor : " + valorAtual + "  *** Erro : " + ex.Message + " *** Detalhe : " + ex.StackTrace);
            }

            return _produtoImportacaoRepository.GetAll();
            
        }

        // CARREGAR TODOS AS LINHAS NA MEMÓRIA PRIMEIRO
        public IEnumerable<ProdutoImportacao> ImportarTxt_Producao(string CaminhoArquivoImportacao)
        {
            int linha = 0;
            string valorlinha = string.Empty;
            string colunaAtual = string.Empty;
            string valorAtual = string.Empty;

            try
            {
                StreamReader strProdutosImportacao = new StreamReader(CaminhoArquivoImportacao);
                ProdutoImportacao objProdutoImportacao = new ProdutoImportacao();
                List<ProdutoImportacao> objProdutosImportacao = new List<ProdutoImportacao>();

                // LIMPAR A TABELA
                _itemControleInventarioRepository.RemoveAll();
                _produtoImportacaoRepository.RemoveAll();

                while (strProdutosImportacao.Peek() > -1)
                {
                    linha++;

                    valorlinha = strProdutosImportacao.ReadLine();

                    colunaAtual = "Data"; valorAtual = "DateTime.Now";
                    objProdutoImportacao.Data = DateTime.Now; // TESTE - RETIRAR
                    colunaAtual = "NumeroLoja"; valorAtual = valorlinha.Substring(0, 6);
                    objProdutoImportacao.NumeroLoja = Convert.ToInt32(valorAtual);
                    colunaAtual = "CodigoEan"; valorAtual = valorlinha.Substring(12, 13);
                    objProdutoImportacao.CodigoEan = Convert.ToInt64(valorAtual);
                    colunaAtual = "NomeProduto"; valorAtual = valorlinha.Substring(25, 50);
                    objProdutoImportacao.NomeProduto = valorAtual;

                    colunaAtual = "PrecoUnitario"; valorAtual = valorlinha.Substring(75, 7) + "," + valorlinha.Substring(82, 2);
                    objProdutoImportacao.PrecoUnitario = Convert.ToDecimal(valorAtual);

                    colunaAtual = "PrecoVendaUnitario"; valorAtual = valorlinha.Substring(84, 7) + "," + valorlinha.Substring(91, 2);
                    objProdutoImportacao.PrecoVendaUnitario = Convert.ToDecimal(valorAtual);

                    colunaAtual = "Quantidade"; valorAtual = valorlinha.Substring(93, 5) + "," + valorlinha.Substring(98, 3);
                    objProdutoImportacao.Quantidade = Convert.ToDecimal(valorAtual);

                    colunaAtual = "DepartamentoId"; valorAtual = valorlinha.Substring(101, 8);
                    objProdutoImportacao.DepartamentoId = Convert.ToInt32(valorAtual);
                    colunaAtual = "NomeDepartamento"; valorAtual = valorlinha.Substring(109, 50);
                    objProdutoImportacao.NomeDepartamento = valorAtual;
                    colunaAtual = "SecaoId"; valorAtual = valorlinha.Substring(159, 8);
                    objProdutoImportacao.SecaoId = Convert.ToInt32(valorAtual);
                    colunaAtual = "NomeSecao"; valorAtual = valorlinha.Substring(167, 50);
                    objProdutoImportacao.NomeSecao = valorAtual;
                    colunaAtual = "GrupoId"; valorAtual = valorlinha.Substring(217, 8);
                    objProdutoImportacao.GrupoId = Convert.ToInt32(valorAtual);
                    colunaAtual = "NomeGrupo"; valorAtual = valorlinha.Substring(225, 50);
                    objProdutoImportacao.NomeGrupo = valorAtual;
                    colunaAtual = "SubGrupoId"; valorAtual = valorlinha.Substring(275, 8);
                    objProdutoImportacao.SubGrupoId = Convert.ToInt32(valorAtual);
                    colunaAtual = "NomeSubGrupo"; valorAtual = valorlinha.Substring(283, 8);
                    objProdutoImportacao.NomeSubGrupo = valorAtual;

                    colunaAtual = "Identificador"; valorAtual = valorlinha.Substring(100, 8);
                    objProdutoImportacao.Identificador = Convert.ToInt32(valorAtual);

                    objProdutosImportacao.Add(objProdutoImportacao);                   

                    objProdutoImportacao = new ProdutoImportacao();

                }

                // PERSISTIR
                foreach (ProdutoImportacao item in objProdutosImportacao)
                {
                     _produtoImportacaoRepository.Add(item);
                }



            }
            catch (Exception ex)
            {
                // PENDENTE 18/02/2015 - 17:18
                // INCLUIR ERRO NO LOG GERAL
                // INCLUIR ERRO NA TABELA DE ERRO DE IMPORTACAO
                throw new ArgumentException("Erro na linha: " + linha.ToString() + " *** Campo : " + colunaAtual + " *** Valor : " + valorAtual + "  *** Erro : " + ex.Message + " *** Detalhe : " + ex.StackTrace);
            }

            return _produtoImportacaoRepository.GetAll();

        }

        // Bulk Copy - FUNCIONANDO !!! - Ok
        public IEnumerable<ProdutoImportacao> ImportarTxt(string CaminhoArquivoImportacao, string strConnection)
        {
            int linha = 0;
            string valorlinha = string.Empty;
            string colunaAtual = string.Empty;
            string valorAtual = string.Empty;

            try
            {
                StreamReader strProdutosImportacao = new StreamReader(CaminhoArquivoImportacao);
                ProdutoImportacao objProdutoImportacao = new ProdutoImportacao();
                List<ProdutoImportacao> objProdutosImportacao = new List<ProdutoImportacao>();

                // LIMPAR A TABELA
                _itemControleInventarioRepository.RemoveAll();
                _produtoImportacaoRepository.RemoveAll();

                while (strProdutosImportacao.Peek() > -1)
                {
                    linha++;

                    valorlinha = strProdutosImportacao.ReadLine();

                    colunaAtual = "Data"; valorAtual = "DateTime.Now";
                    objProdutoImportacao.Data = DateTime.Now; // TESTE - RETIRAR
                    colunaAtual = "NumeroLoja"; valorAtual = valorlinha.Substring(0, 6);
                    objProdutoImportacao.NumeroLoja = Convert.ToInt32(valorAtual);
                    colunaAtual = "CodigoEan"; valorAtual = valorlinha.Substring(12, 13);
                    objProdutoImportacao.CodigoEan = Convert.ToInt64(valorAtual);
                    colunaAtual = "NomeProduto"; valorAtual = valorlinha.Substring(25, 50);
                    objProdutoImportacao.NomeProduto = valorAtual;

                    colunaAtual = "PrecoUnitario"; valorAtual = valorlinha.Substring(75, 7) + "," + valorlinha.Substring(82, 2);
                    objProdutoImportacao.PrecoUnitario = Convert.ToDecimal(valorAtual);

                    colunaAtual = "PrecoVendaUnitario"; valorAtual = valorlinha.Substring(84, 7) + "," + valorlinha.Substring(91, 2);
                    objProdutoImportacao.PrecoVendaUnitario = Convert.ToDecimal(valorAtual);

                    colunaAtual = "Quantidade"; valorAtual = valorlinha.Substring(93, 8) + "," + valorlinha.Substring(101, 4);
                    objProdutoImportacao.Quantidade = Convert.ToDecimal(valorAtual);

                    colunaAtual = "DepartamentoId"; valorAtual = valorlinha.Substring(105, 8);
                    objProdutoImportacao.DepartamentoId = Convert.ToInt32(valorAtual);
                    colunaAtual = "NomeDepartamento"; valorAtual = valorlinha.Substring(113, 50);
                    objProdutoImportacao.NomeDepartamento = valorAtual;
                    colunaAtual = "SecaoId"; valorAtual = valorlinha.Substring(163, 8);
                    objProdutoImportacao.SecaoId = Convert.ToInt32(valorAtual);
                    colunaAtual = "NomeSecao"; valorAtual = valorlinha.Substring(171, 50);
                    objProdutoImportacao.NomeSecao = valorAtual;
                    colunaAtual = "GrupoId"; valorAtual = valorlinha.Substring(221, 8);
                    objProdutoImportacao.GrupoId = Convert.ToInt32(valorAtual);
                    colunaAtual = "NomeGrupo"; valorAtual = valorlinha.Substring(229, 50);
                    objProdutoImportacao.NomeGrupo = valorAtual;
                    colunaAtual = "SubGrupoId"; valorAtual = valorlinha.Substring(279, 8);
                    objProdutoImportacao.SubGrupoId = Convert.ToInt32(valorAtual);
                    colunaAtual = "NomeSubGrupo"; valorAtual = valorlinha.Substring(287, 8);
                    objProdutoImportacao.NomeSubGrupo = valorAtual;

                    colunaAtual = "Identificador"; valorAtual = valorlinha.Substring(104, 8);
                    objProdutoImportacao.Identificador = Convert.ToInt32(valorAtual);

                    objProdutosImportacao.Add(objProdutoImportacao);

                    objProdutoImportacao = new ProdutoImportacao();

                }

                //Pass in cnx, tablename, and list of imports
                BulkInsert(strConnection, "ProdutoImportacao", "ProdutoImportacaoId", objProdutosImportacao);

            }
            catch (Exception ex)
            {
                // PENDENTE 18/02/2015 - 17:18
                // INCLUIR ERRO NO LOG GERAL
                // INCLUIR ERRO NA TABELA DE ERRO DE IMPORTACAO
                throw new ArgumentException("Erro na linha: " + linha.ToString() + " *** Campo : " + colunaAtual + " *** Valor : " + valorAtual + "  *** Erro : " + ex.Message + " *** Detalhe : " + ex.StackTrace);
            }

            return _produtoImportacaoRepository.GetAll();

        }

        private static void BulkInsert<T>(string connection, string tableName, string colunaId, IList<T> list)
        {
            using (var bulkCopy = new SqlBulkCopy(connection))
            {
                bulkCopy.BatchSize = list.Count;
                bulkCopy.DestinationTableName = tableName;

                DataTable table;
                var props = TypeDescriptor.GetProperties(typeof(T))
                    //Dirty hack to make sure we only have system data types
                    //i.e. filter out the relationships/collections
                .Cast<PropertyDescriptor>()
                .Where(propertyInfo => propertyInfo.PropertyType.Namespace.Equals("System"))
                .ToArray();
                foreach (var propertyInfo in props)
                {
                    if (!propertyInfo.Name.Equals(colunaId))
                    {

                        bulkCopy.ColumnMappings.Add(propertyInfo.Name, propertyInfo.Name);
                        //table.Columns.Add(propertyInfo.Name, Nullable.GetUnderlyingType(propertyInfo.PropertyType) ?? propertyInfo.PropertyType);
                        
                    }                    
                }

                table = ConvertToDataTable(list, colunaId);

                bulkCopy.WriteToServer(table);
            }
        }

        private static DataTable ConvertToDataTable<T>(IList<T> data, string ColunaId)
        {
            PropertyDescriptorCollection properties =
               TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();


            foreach (PropertyDescriptor prop in properties)
            {
                if (!prop.Name.Equals(ColunaId))
                {
                    table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
                }
            }

            foreach (T item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                {
                    if (!prop.Name.Equals(ColunaId))
                    {

                        row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                        
                    }                    
                }
                table.Rows.Add(row);
 
            }
            return table;
        } 

    }
}
