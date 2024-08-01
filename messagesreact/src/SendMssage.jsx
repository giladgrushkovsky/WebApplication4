import { useEffect, useMemo, useState } from "react";

const SendMessage = (props)=>{
    const {workers , currentWorker} = props;
    const [currentUserId , setCurrentUserId] = useState('-1');
    const [textMessage , setTextMessage] = useState('');
    const [messages, setMessages] = useState([]);
    const [disableSend ,setDisableSend ] = useState(true);


    const filteredWorkers = useMemo(()=>{
        setCurrentUserId(-1);
        setTextMessage('');
        if(!currentWorker){
            return [];
        }
        const res = [{Id:-1 ,Name:'select'},...workers.filter((w)=>{
            return w.Id !=currentWorker.Id;
        })];
        

        return res;
    },[workers,currentWorker])

    useEffect(()=>{
        const res = currentUserId !== '-1' && textMessage.length !== 0 ? false :true;
        // debugger;
        setDisableSend(res);
    },[currentUserId,textMessage])

    const SelectUserTosend = (id)=>{
        setCurrentUserId(id);
    }
    
     async function SendMessage (){
        
        const data = {  Id: currentUserId,
            message: textMessage};
            
        const res = await fetch(
            `https://localhost:44355/Message/SendMessage`,
            {method: 'POST',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json',
            },
            body: JSON.stringify( data)
     });
    }
    return (
        <form
        onSubmit={(e)=>{
            e.preventDefault();
            SendMessage();
            
        }}
        >   
            <select id="workerId" style={{width:'100%'}}
            onChange={(e) => SelectUserTosend(e.target.value)}
            onBlur={(e) => SelectUserTosend(e.target.value)}
            value={currentUserId}
            disabled={currentWorker? false : true }
            >
                {filteredWorkers.map((worker)=>(<option key={worker.Id} value={worker.Id}>{worker.Name} {worker.LastName}</option> ))}
            </select>
            <textarea 
            value={textMessage}
            disabled={currentWorker? false : true }
            onChange={(e)=>{setTextMessage(e.target.value)}}
            
            style={{width:'100%', height:'200px'}} id="message Text"></textarea>
            {disableSend}
            <button disabled={disableSend} style={{width:'100%'}} type="submit"> Send </button>

        </form>
        
    )

}

export default SendMessage;