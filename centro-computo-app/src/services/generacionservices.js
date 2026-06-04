import api from './api'


const endPoint= 'Generaciones'
export const listar = async () => {
    const response = await api.get(endPoint);
    return response.data;
}

export default {
  
    create(data)
    {
        return api.post(endPoint,data);
    },
    delete(id)
    {
        return api.delete(`{endPoint}/${id}`);
     
    },
    update(id,data)
    {
        return api.put(`{endPoint}/${id}`,data)
    } 
}







