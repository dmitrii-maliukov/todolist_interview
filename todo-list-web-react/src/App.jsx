import React, { useState } from "react";
import TodoLists from "./components/TodoLists";
import AddTodoList from "./components/AddTodoList";
import "./App.css";

const App = () => {
    const [refreshKey, setRefreshKey] = useState(0);
    const [showForm, setShowForm] = useState(false);

    const handleRefresh = () => {
        setRefreshKey((prev) => prev + 1);
    };

    const toggleForm = () => {
        setShowForm((prev) => !prev);
    };

    const handleSuccess = () => {
        setShowForm(false);
        handleRefresh();
    };

    return (
        <div className="app-container">
            {!showForm && (
                <button className="add-new-list-button" onClick={toggleForm}>
                    Add New
                </button>
            )}

            <div className={`form-wrapper ${showForm ? "slide-in" : "slide-out"}`}>
                {showForm && (
                    <AddTodoList onSuccess={handleSuccess} onClose={toggleForm} />
                )}
            </div>

            <div className="todo-lists-wrapper">
                <TodoLists refreshKey={refreshKey} />
            </div>
        </div>
    );
};

export default App;