
import Worker from "./Worker";



const Workers = (props)=>{
    const {setCurrentWorker ,workers ,currentWorkerId } = props;
    
    return (
        <div className="workerList">
            {workers.map((worker)=>{return( 
                    // eslint-disable-next-line react/jsx-key
                    <Worker 
                    {...worker}
                    currentWorkerId={currentWorkerId}
                    key={worker.Id}
                     setCurrentworker={setCurrentWorker}/>
            )})}
         </div>
    )
}

export default Workers;
