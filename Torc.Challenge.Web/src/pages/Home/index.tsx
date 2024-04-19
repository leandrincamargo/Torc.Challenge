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

const DefaultParams = {
  searchBy: '',
  searchValue: '',
  books: [] as Book[],
  book: {} as Book,
  loading: false,
  page: 0,
  rowsPerPage: 10,
  totalItems: 0,
  openModal: false,
};

const Home = () => {
  const [searchBy, setSearchBy] = useState<SearchBook | string>(
    DefaultParams.searchBy
  );
  const [searchValue, setSearchValue] = useState<string>(
    DefaultParams.searchValue
  );
  const [loading, setLoading] = useState<boolean>(DefaultParams.loading);
  const [books, setBooks] = useState<Book[]>(DefaultParams.books);
  const [page, setPage] = useState<number>(DefaultParams.page);
  const [openModal, setOpenModal] = useState<boolean>(DefaultParams.openModal);
  const [book, setBook] = useState<Book>(DefaultParams.book);
  const [rowsPerPage, setRowsPerPage] = useState<number>(
    DefaultParams.rowsPerPage
  );
  const [totalItems, setTotalItems] = useState<number>(
    DefaultParams.totalItems
  );

  const onSearchBooks = async (newPage: number, newRowsPerPage: number) => {
    newPage = newPage < 0 ? page : newPage;
    newRowsPerPage = newRowsPerPage < 0 ? rowsPerPage : newRowsPerPage;
    setLoading(true);
    let items = [] as Book[];
    try {
      const { data } = await api.get(
        `/api/books?field=${searchBy}&value=${searchValue}&page=${newPage}&rowsPerPage=${newRowsPerPage}`
      );
      items = data.items;
      setPage(data.currentPage);
      setTotalItems(data.totalItemCount);
    } catch (e) {
      console.error(e);
      items = [] as Book[];
      setPage(DefaultParams.page);
      setTotalItems(DefaultParams.totalItems);
    }
    setBooks(items);
    setLoading(false);
  };

  const onEditBook = (book: Book) => {
    setLoading(true);
    setBook(book);
    setOpenModal(true);
    setLoading(false);
  };

  useEffect(() => {
    setSearchBy(DefaultParams.searchBy);
    setSearchValue(DefaultParams.searchValue);
    setBooks(DefaultParams.books);
    setPage(DefaultParams.page);
    setRowsPerPage(DefaultParams.rowsPerPage);
    setTotalItems(DefaultParams.totalItems);
    setOpenModal(DefaultParams.openModal);
    onSearchBooks(DefaultParams.page, DefaultParams.rowsPerPage);
  }, []);

  return (
    <div id="page-home">
      <div className="content">
        <main>
          <h1>Royal Library</h1>
          {loading ? <LoadingOverlay loading={loading} /> : <></>}
          <NewBookModal
            open={openModal}
            setOpenModal={setOpenModal}
            book={book}
            setBook={setBook}
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
                <Button
                  variant="contained"
                  color="primary"
                  onClick={() => onSearchBooks(DefaultParams.page, rowsPerPage)}
                >
                  Search
                </Button>
                <Button
                  variant="contained"
                  color="primary"
                  onClick={() => onEditBook({} as Book)}
                >
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
              page={page}
              setPage={setPage}
              rowsPerPage={rowsPerPage}
              setRowsPerPage={setRowsPerPage}
              totalItems={totalItems}
              onEditBook={onEditBook}
            />
          </Card>
        </main>
      </div>
    </div>
  );
};

export default Home;
