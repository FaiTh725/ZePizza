import { BrowserRouter, Route, Routes } from 'react-router-dom'
import './App.css'
import Home from './Pages/HomeScreen'
import ProfileScreen from './Pages/ProfileScreen'

function App() {

  return (
    <BrowserRouter>
      <Routes>
        <Route path='*' element={<Home/>}/>
        <Route path='/profile' element={<ProfileScreen/>}/>
      </Routes>
    </BrowserRouter>
  )
}

export default App
