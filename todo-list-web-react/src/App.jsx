import React, { useState } from "react";
import TodoLists from "./components/TodoLists";
import AddTodoList from "./components/AddTodoList";
import "./App.css";
import { QueryClient, QueryClientProvider } from "@tanstack/react-query";

const queryClient = new QueryClient();

const App = () => {
    const [showForm, setShowForm] = useState(false);

    const toggleForm = () => setShowForm(prev => !prev);

    const handleSuccess = () => {
        setShowForm(false);
        queryClient.invalidateQueries({ queryKey: ["todoLists"] });
    };

    return (
        <QueryClientProvider client={queryClient}>
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
                    <TodoLists />
                </div>
            </div>
        </QueryClientProvider>
    );
};
export default App;