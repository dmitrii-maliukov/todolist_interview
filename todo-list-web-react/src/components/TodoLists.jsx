import React, { useEffect, useState } from "react";
import { getTodoLists } from "../api/todoLists";
import "./TodoLists.css";

const PAGE_SIZE = 10;

const TodoLists = ({ refreshKey }) => {
    const [todoData, setTodoData] = useState([]);
    const [page, setPage] = useState(1);
    const [totalCount, setTotalCount] = useState(0);
    const [loading, setLoading] = useState(false);
    const [error, setError] = useState(null);

    const fetchPage = async (pageNumber) => {
        try {
            setLoading(true);
            const data = await getTodoLists(PAGE_SIZE, pageNumber);

            if (pageNumber === 1) setTodoData(data.items);
            else setTodoData((prev) => [...prev, ...data.items]);

            setTotalCount(data.totalCount || 0);
        } catch (err) {
            setError(err.message || "Failed to fetch todo lists");
        } finally {
            setLoading(false);
        }
    };

    useEffect(() => {
        fetchPage(1);
        setPage(1);
    }, [refreshKey]);

    const loadMore = () => {
        if (todoData.length < totalCount) {
            const nextPage = page + 1;
            setPage(nextPage);
            fetchPage(nextPage);
        }
    };

    if (error) return <div className="error">Error: {error}</div>;

    return (
        <div className="todo-container">
            {todoData.map((list) => (
                <div key={list.id} className="todo-list">
                    <p className="list-title">{list.title}</p>
                    {list.Description && <p className="list-description">{list.description}</p>}
                    <ul className="todo-items">
                        {list.todoItems.map((item) => (
                            <li key={item.id} className="todo-item-in-list">
                                <strong
                                    className="item-title"
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

            {todoData.length < totalCount && (
                <div className="load-more-container">
                    <button className="load-more-btn" onClick={loadMore} disabled={loading}>
                        {loading ? "Loading..." : "Load More"}
                    </button>
                </div>
            )}
        </div>
    );
};

export default TodoLists;