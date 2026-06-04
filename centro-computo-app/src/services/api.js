import axios from "axios";
const url = 'https://localhost:7045/api/'
const api = axios.create ({
baseURL: url,
headers: {
    'Content-Type': 'application/json'
}
});


export default api;