// import { useState } from 'react'
// import reactLogo from './assets/react.svg'
// import viteLogo from '/vite.svg'
import { useEffect, useState } from 'react'
import './App.css'
import Workers from './Workers'
import WorkerFullDetails from './WorkerFullDetails';
import { Gender ,DepartmentType ,WorkerType} from './enums';
import SendMessage from './SendMssage';
import MessageList from './MessageList';

function App() {
  const [currentWorker , setCurrentWorker] = useState(null);
  const [workers, setWorkers] = useState([]);
  const updateCurrentWorker = (index)=>{
    setCurrentWorker(workers[index-1]);
  }
    useEffect(()=>{
        requestWorkers();
    },[])// eslint-disable-line react-hooks/exhaustive-deps

    
    async function requestWorkers() {

        const res = await fetch(
          `https://localhost:44355/Organization/getworkers`
        );
        const json = await res.json();
        const updateJson = json.map((o=>{
          o.Gender = Object.keys(Gender)[o.Gender]
          o.DepartmentType = Object.keys(DepartmentType)[o.DepartmentType]
          o.WorkerType = Object.keys(WorkerType)[o.WorkerType]
          return o;
        }))

        

        setWorkers(updateJson);
      }

  return (
    <>
      <div className='app'>
        
        <Workers workers={workers} setCurrentWorker={updateCurrentWorker} currentWorkerId={currentWorker?.Id} />
        <div className='sendMessageDetails'>
          <WorkerFullDetails {...currentWorker} />
          <SendMessage workers={workers} currentWorker={currentWorker} />

        </div>
          <MessageList currentWorker={currentWorker} />
      </div>
       
    </>
  )
}

export default App
