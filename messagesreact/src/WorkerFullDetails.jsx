const WorkerFullDetails = (props)=>{
    // eslint-disable-next-line react/prop-types
    const {Id, Name, LastName,PhoneNumber ,Address,Gender ,DepartmentType ,WorkerType } = props
    if(Id == null)
        return(
            <div className="workerDetails"   > no user selected</div>
    )
    return(
        <div className="workerDetails"   >
            <p>{Name} {LastName}</p>
            <p>{Address}</p>
            <p>{PhoneNumber}</p>
            <p>{Gender}</p>
            <p>{DepartmentType}</p>
            <p>{WorkerType}</p>
        </div>
    )
}

export default WorkerFullDetails;