import React, { useEffect, useState } from "react";
import { getTodoLists } from "../api/todoLists";
import "./TodoLists.css";

const TodoLists = () => {
    const [todoData, setTodoData] = useState([]);
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState(null);

    useEffect(() => {
        const fetchTodoLists = async () => {
            try {
                const data = await getTodoLists();
                setTodoData(data.items);
            } catch (err) {
                setError(err.message || "Failed to fetch todo lists");
            } finally {
                setLoading(false);
            }
        };

        fetchTodoLists();
    }, []);

    if (loading) return <div className="loading">Loading...</div>;
    if (error) return <div className="error">Error: {error}</div>;

    return (
        <div className="todo-container">
            {todoData.map((list) => (
                <div key={list.id} className="todo-list">
                    <p className="list-title">{list.title}</p>
                    {list.description && <p className="list-description">{list.description}</p>}
                    <ul className="todo-items">
                        {list.todoItems.map((item) => (
                            <li
                                key={item.id}
                                className="todo-item-in-list"
                            >
                                <strong
                                    style={{ textDecoration: item.isCompleted ? "line-through" : "none" }}
                                >
                                    {item.title}
                                </strong>
                                {item.description && <div className="item-description">{item.description}</div>}
                            </li>
                        ))}
                    </ul>
                </div>
            ))}
        </div>
    );
};

export default TodoLists;