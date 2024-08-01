const Worker = (props)=>{
    // eslint-disable-next-line react/prop-types
    const {Id,Name, LastName ,DepartmentType ,WorkerType , setCurrentworker, currentWorkerId} = props;
    
    
    return(
        <div className={`worker ${currentWorkerId == Id ? 'current' : '' }`} onClick={()=>setCurrentworker(Id)}  >
            
            <p>{Name} {LastName}</p>
            <p>{DepartmentType}</p>
            <p>{WorkerType}</p>
        </div>
    )
}

export default Worker;