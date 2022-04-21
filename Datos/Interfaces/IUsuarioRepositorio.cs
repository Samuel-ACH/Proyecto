﻿using Modelos;

namespace Datos.Interfaces;

public interface IUsuarioRepositorio
{
    Task<bool>Enviar(Doctores doctores);
}
