using System;
using PetShop.Models;

namespace PetShop.Repositories;

public interface IContaPagarRepository
{
    void Adicionar(ContaPagar conta);
    List<ContaPagar> Listar();
    ContaPagar? BuscarPorId(int id);
    void Atualizar(ContaPagar conta);
    void Remover(int id);
}
