using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs.Actividades;
using Application.DTOs.Entidades;
using Application.Interfaces.Actividades;
using Dominio.AggregateRoots.Actividades;

namespace Aplicacion.Servicios.Actividades
{
    public class ActividadService : IActividadService
    {
        private readonly IActividadRepository _actividadRepository;

        public ActividadService(IActividadRepository actividadRepository)
        {
            _actividadRepository = actividadRepository;
        }

        public async Task<IEnumerable<ActividadResponseDTO>> GetAllAsync()
        {
            var actividades = await _actividadRepository.GetAllAsync();
            return actividades.Select(a => new ActividadResponseDTO
            {
                Id = a.Id,
                Descripcion = a.Descripcion,
                FechaHoraInicio = a.FechaHoraInicio,
                Finalizado = a.Finalizado,
                FechaFinalizado = a.FechaFinalizado,
                UsuarioId = a.UsuarioId,
                Usuario = a.Usuario != null ? new UsuarioResponseDTO { Id = a.Usuario.Id, Nombre = a.Usuario.Nombre } : null,
                TipoId = a.TipoId,
                Tipo = a.Tipo != null ? new TipoResponseDTO { Id = a.Tipo.Id, Nombre = a.Tipo.Nombre } : null,
                Tareas = a.Tareas != null
    ? a.Tareas.Select(t => new TareaResponseDTO
    {
        Id = t.Id,
        Descripcion = t.Descripcion, 
        Finalizado = t.Finalizado,  
        FechaHoraInicio = t.FechaHoraInicio,
        FechaHoraFinal = t.FechaHoraFinal
    }).ToList()
    : new List<TareaResponseDTO>()

            });
        }

        public async Task<ActividadResponseDTO?> GetByIdAsync(int id)
        {
            var a = await _actividadRepository.GetByIdAsync(id);
            return a is null ? null : new ActividadResponseDTO
            {
                Id = a.Id,
                Descripcion = a.Descripcion,
                FechaHoraInicio = a.FechaHoraInicio,
                Finalizado = a.Finalizado,
                FechaFinalizado = a.FechaFinalizado,
                UsuarioId = a.UsuarioId,
                TipoId = a.TipoId,
                Usuario = a.Usuario != null ? new UsuarioResponseDTO { Id = a.Usuario.Id, Nombre = a.Usuario.Nombre } : null,
                Tipo = a.Tipo != null ? new TipoResponseDTO { Id = a.Tipo.Id, Nombre = a.Tipo.Nombre } : null,
                Tareas = a.Tareas != null
    ? a.Tareas.Select(t => new TareaResponseDTO
    {
        Id = t.Id,
        Descripcion = t.Descripcion, 
        Finalizado = t.Finalizado,  
        FechaHoraInicio = t.FechaHoraInicio,
        FechaHoraFinal = t.FechaHoraFinal
    }).ToList()
    : new List<TareaResponseDTO>()

            };
        }

        public async Task<ActividadResponseDTO> CreateAsync(ActividadRequestDTO dto)
        {
            var actividad = new Actividad
            {
                Descripcion = dto.Descripcion,
                FechaHoraInicio = dto.FechaHoraInicio,
                Finalizado = dto.Finalizado,
                UsuarioId = dto.UsuarioId,
                TipoId = dto.TipoId,
                Tareas = dto.Tareas != null
            ? dto.Tareas.Select(t => new Tarea
            {
                Descripcion = t.Descripcion,
                Finalizado = t.Finalizado,
                FechaHoraInicio = t.FechaHoraInicio,
                FechaHoraFinal = t.FechaHoraFinal
            }).ToList()
            : new List<Tarea>()

            };

            await _actividadRepository.AddAsync(actividad);

            return new ActividadResponseDTO
            {
                Id = actividad.Id,
                Descripcion = actividad.Descripcion,
                FechaHoraInicio = actividad.FechaHoraInicio,
                Finalizado = actividad.Finalizado,
                UsuarioId = actividad.UsuarioId,
                TipoId = actividad.TipoId,
                Tareas = actividad.Tareas.Select(t => new TareaResponseDTO
                {
                    Id = t.Id,
                    Descripcion = t.Descripcion,
                    Finalizado = t.Finalizado,
                    FechaHoraInicio = t.FechaHoraInicio,
                    FechaHoraFinal = t.FechaHoraFinal
                }).ToList()
            };
        }

        public async Task<bool> UpdateAsync(int id, ActividadRequestDTO dto)
        {
            var actividad = await _actividadRepository.GetByIdAsync(id);
            if (actividad is null) return false;

            actividad.Descripcion = dto.Descripcion;
            actividad.FechaHoraInicio = dto.FechaHoraInicio;
            actividad.Finalizado = dto.Finalizado;
            actividad.FechaFinalizado = dto.Finalizado ? (DateTime?)DateTime.UtcNow : null;
            actividad.UsuarioId = dto.UsuarioId;
            actividad.TipoId = dto.TipoId;

            // Actualizar tareas
            actividad.Tareas.Clear();
            actividad.Tareas.AddRange(dto.Tareas.Select(t => new Tarea
            {
                Descripcion = t.Descripcion,  
                Finalizado = t.Finalizado,    
                FechaHoraInicio = t.FechaHoraInicio,
                FechaHoraFinal = t.FechaHoraFinal
            }));

            return await _actividadRepository.UpdateAsync(actividad);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _actividadRepository.DeleteAsync(id);
        }
    }
}
