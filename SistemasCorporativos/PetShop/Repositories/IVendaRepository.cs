using System;

using System.Collections.Generic;
using PetShop.Models;

namespace PetShop.Repositories;

    public interface IVendaRepository
    {
        void CadastrarVenda(Venda venda);
        Venda? BuscarPorId(int id);
        List<Venda> ListarTodas();
        void AtualizarVenda(Venda venda);
        void RemoverVenda(int id);
        }


