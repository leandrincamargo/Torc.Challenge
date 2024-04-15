import React, { useEffect, useState } from 'react';
import { SearchBook } from '../../components/types/SearchBooks.types';
import Card from '@mui/material/Card';
import CardContent from '@mui/material/CardContent';
import FormControl from '@mui/material/FormControl';
import MenuItem from '@mui/material/MenuItem';
import Select from '@mui/material/Select';
import Button from '@mui/material/Button';
import InputLabel from '@mui/material/InputLabel';
import TextField from '@mui/material/TextField';

import api from '../../services/api';

import { Book } from '../../components/types/Books.types';

import LoadingOverlay from '../../components/LoadingOverlay';
import SearchResultsTable from '../../components/SearchResultsTable';
import NewBookModal from '../../components/NewBookModal';

import './style.css';

const Home = () => {
  const [searchBy, setSearchBy] = useState<SearchBook | string>('');
  const [searchValue, setSearchValue] = useState<string>('');
  const [loading, setLoading] = useState<boolean>(false);
  const [newBook, setNewBook] = useState<boolean>(false);
  const [books, setBooks] = useState<Book[]>([]);

  const onSearchBooks = async () => {
    setLoading(true);
    const { data } = await api.get(`/api/books?field=${searchBy}&value=${searchValue}`);
    setBooks(data.items);
    setLoading(false);
  };

  useEffect(() => {
    setSearchBy('');
    setSearchValue('');
    onSearchBooks();
  }, []);

  return (
    <div id="page-home">
      <div className="content">
        <main>
          <h1>Royal Library</h1>
          {loading ? <LoadingOverlay loading={loading} /> : <></>}
          <NewBookModal
            open={newBook}
            setNewBook={setNewBook}
            book={{} as Book}
            setLoading={setLoading}
            onSearchBooks={onSearchBooks}
          />
          <Card style={{ margin: '20px', padding: '20px' }}>
            <CardContent>
              <FormControl fullWidth style={{ marginBottom: '20px' }}>
                <InputLabel id="search-by-label">Search By:</InputLabel>
                <Select
                  labelId="search-by-label"
                  id="search-by"
                  value={searchBy}
                  onChange={(e: any) => setSearchBy(e.target.value as string)}
                >
                  {Object.keys(SearchBook).map((key, index) => (
                    <MenuItem key={key} value={key}>
                      <em>{key}</em>
                    </MenuItem>
                  ))}
                </Select>
              </FormControl>
              <TextField
                fullWidth
                label="Search Value:"
                value={searchValue}
                onChange={(e: any) => setSearchValue(e.target.value)}
                style={{ marginBottom: '20px' }}
              />
              <div style={{ display: 'flex', justifyContent: 'space-between' }}>
                <Button variant="contained" color="primary" onClick={onSearchBooks}>
                  Search
                </Button>
                <Button variant="contained" color="primary" onClick={() => setNewBook(true)}>
                  Add New Book
                </Button>
              </div>
            </CardContent>
          </Card>

          <Card style={{ maxHeight: '530px', overflow: 'scroll' }}>
            <SearchResultsTable
              booksData={books}
              setLoading={setLoading}
              onSearchBooks={onSearchBooks}
            />
          </Card>
        </main>
      </div>
    </div>
  );
};

export default Home;
