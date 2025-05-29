using System;
using PetShop.Models;

namespace PetShop.Repositories;

public interface IContaReceberRepository
{
    void Adicionar(ContaReceber conta);
    List<ContaReceber> Listar();
    void Receber(int id);
}

