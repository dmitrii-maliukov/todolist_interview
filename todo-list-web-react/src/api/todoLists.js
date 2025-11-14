import axios from 'axios';

export const getTodoLists = async (pageSize, pageNumber) => {
    const response = await axios
        .get(`/api/todo-lists?pageSize=${pageSize}&pageNumber=${pageNumber}`);
    console.log(response.data);
    return response.data;
};

export const addTodoList = (newItem) => {
    try {
        return axios.post('/api/todo-lists', newItem);
    } catch (error) {
        if (error.response && error.response.status === 400) {
            const errors = error.response.data.errors;
            const errorMessages = Object.entries(errors)
                .map(([field, messages]) => `${field}: ${messages.join(', ')}`)
                .join('\n');

            console.error('Validation failed:', errorMessages);
            throw new Error(errorMessages);
        } else {
            console.error('Unexpected error:', error);
            throw error;
        }

    }
};