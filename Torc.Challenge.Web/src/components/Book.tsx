// import React, { useEffect, useState } from 'react';
// import '.App.css';
// import { api, getAllBooks } from '../services/api';
// import { Book } from './Books.types';

// function App() {
//   const [loading, setLoading] = useState<Boolean>(false);
//   const [books, setBooks] = useState<Book[]>([]);
//   const [bookSelected, setBookSelected] = useState<Book | null>(null);

//   useEffect(() => {
//     async function getBooks() {
//       setLoading(true);
//       const data = await getAllBooks();
//       setBooks(data);
//       setLoading(false);
//     }
//     getBooks();
//   }, []);

//   return (
//     <div className="App">
//       <h1>Book Store</h1>
//       <header className="App-header">
//         <p>Book Store</p>
//         <a
//           className="App-link"
//           href="https://reactjs.org"
//           target="_blank"
//           rel="noopener noreferrer"
//         >
//           Learn React
//         </a>
//       </header>
//     </div>
//   );
// }

// export default App;
