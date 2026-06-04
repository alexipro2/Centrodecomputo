<template>
<div class = "container-md mt-5">
    <div class = "card"> 
        <div class ="card-header">
        <h2>Lista de generaciones</h2>
    </div>
    <div class="card-body">
        <table class="table">
            <thead>
                <tr>
                    <th>Codigo</th>
                    <th>Nombre</th>
                    <th class="text-end">Acciones</th>

                </tr>
            </thead>
            <tbody>
                <tr v-for="gen in Generaciones" :key="gen.id">
                    <td>{{ gen.id }}</td>
                    <td>{{ gen.nombre }}</td>
                    <td class="text-end">
                        <button class="btn btn-warning m-2">Editar</button>
                        <button class="btn btn-danger m-2">Eliminar</button>
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
    </div>

   
</div>
    </template>
    
    <script setup>
    
    import {ref,onMounted} from 'vue' 
    import{listar} from '@/services/generacionservices'
    const Generaciones = ref([])
    
    onMounted (async()=>
    { 
        const response= await listar();
        Generaciones.value=response;
    });



    </script>
    
    <style scoped  >
    
    </style>
    